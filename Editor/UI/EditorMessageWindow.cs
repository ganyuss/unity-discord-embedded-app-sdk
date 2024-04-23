using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace DiscordActivitySdk.Editor.UI
{
    internal class EditorMessageWindow : EditorWindow
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        private EditorMessageProvider AssociatedMessageProvider;
        private IDefaultMessageProvider DefaultMessageProvider;
        private readonly List<Type> MessageTypes = FindAllMessageTypes();

        private object currentDiscordEvent;
        
        private DropdownField TypeDropdown;
        private VisualElement EventContainer;
        
        internal static EditorMessageWindow AttachNewWindowTo(EditorMessageProvider messageProvider, IDefaultMessageProvider defaultMessageProvider)
        {
            EditorMessageWindow window = GetWindow<EditorMessageWindow>();
            window.titleContent = new GUIContent("Discord Event Provider");
            
            window.AssociatedMessageProvider = messageProvider;
            window.DefaultMessageProvider = defaultMessageProvider;

            return window;
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            VisualElement xmlLayout = m_VisualTreeAsset.Instantiate();
            root.Add(xmlLayout);

            root.Q<Button>("send-event-button")
                .clicked += SendDiscordEvent;
            
            EventContainer = root.Q("event-container-element");

            TypeDropdown = root.Q<DropdownField>("event-type-dropdown");
            TypeDropdown.choices = MessageTypes.Select(t => t.Name).ToList();
            TypeDropdown.RegisterValueChangedCallback(DropdownValueChanged);
            TypeDropdown.index = 0;
            
            DropdownValueChanged(null);
        }

        private void SendDiscordEvent()
        {
            AssociatedMessageProvider.SendEventFromEditorWindow((DiscordEvent) currentDiscordEvent);
        }

        private static List<Type> FindAllMessageTypes()
        {
            var output = TypeCache.GetTypesDerivedFrom<DiscordEvent>()
                .Where(t => ! t.IsAbstract && ! t.ContainsGenericParameters)
                .ToList();

            output.Sort((t1, t2) => StringComparer.OrdinalIgnoreCase.Compare(t1.Name, t2.Name));

            return output;
        }

        private void DropdownValueChanged(ChangeEvent<string> _)
        {
            var newEventType = MessageTypes[TypeDropdown.index];
            currentDiscordEvent = DefaultMessageProvider?.GetDefaultMessageFor(newEventType) 
                                  ?? Activator.CreateInstance(newEventType);
            
            PopulateEventContainer();
        }

        private void PopulateEventContainer()
        {
            EventContainer.Clear();

            CreateFieldsForObject(EventContainer, currentDiscordEvent);
        }

        private void CreateFieldsForObject(VisualElement container, object obj)
        {
            var properties = obj
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(propertyInfo => propertyInfo.GetSetMethod() != null);

            foreach (var property in properties)
            {
                SetupField(obj, property, container);
            }
        }

        private void SetupField(object obj, PropertyInfo property, VisualElement container)
        {
            if (property.PropertyType.IsGenericType
                && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                || property.CustomAttributes.Any(attr => attr.AttributeType == typeof(CanBeNullAttribute)))
            {
                SetupNewNullableField(obj, property, container);
            }
            else
            {
                SetupNonNullableField(obj, property, container);
            }
        }

        private void SetupNonNullableField(object obj, PropertyInfo property, VisualElement container)
            => SetupNonNullableField(obj, property, container, property.PropertyType, GetDisplayName(property));

        private void SetupNonNullableField(object obj, PropertyInfo property, VisualElement container,
            Type objType, string objName)
        {
            objType ??= property.PropertyType;
            
            if (objType.IsArray)
                SetupNewArrayField(obj, property, container, objName);
            else if (objType == typeof(int))
                SetupNewField<IntegerField, int>(obj, property, container, objName);
            else if (objType == typeof(float))
                SetupNewField<FloatField, float>(obj, property, container, objName);
            else if (objType == typeof(string))
                SetupNewField<TextField, string>(obj, property, container, objName);
            else if (objType == typeof(bool))
                SetupNewField<Toggle, bool>(obj, property, container, objName);
            else if (objType.IsEnum)
            {
                var enumField = SetupNewField<EnumField, Enum>(obj, property, container, objName);
                enumField.Init((Enum)Activator.CreateInstance(objType));
            }
            else
            {
                SetupNewSubObjectField(obj, property, container, objName);
            }
        }

        private void SetupNewNullableField(object obj, PropertyInfo property, VisualElement container)
        {
            Type underlyingType = property.PropertyType;
            if (underlyingType.IsGenericType && underlyingType.GetGenericTypeDefinition() == typeof(Nullable<>))
                underlyingType = underlyingType.GetGenericArguments().First();
            
            var fieldContainer = new VisualElement();
            SetupNonNullableField(obj, property, fieldContainer, underlyingType, "Value");

            
            var nullToggle = new Toggle("null");
            object previousValue = null;
            nullToggle.RegisterValueChangedCallback(evt =>
            {
                if (nullToggle.value)
                {
                    previousValue = property.GetValue(obj);
                    property.SetValue(obj, null);
                }
                else
                {
                    property.SetValue(obj, previousValue);
                }
                
                fieldContainer.SetEnabled(! nullToggle.value);
            });

            nullToggle.value = true;
            fieldContainer.SetEnabled(false);
            
            var foldout = new Foldout
            {
                text = GetDisplayName(property),
                value = false
            };
            
            foldout.contentContainer.Add(nullToggle);
            foldout.contentContainer.Add(fieldContainer);
            foldout.contentContainer.style.paddingLeft = 0;
            
            container.Add(foldout);
        }

        private void SetupNewArrayField(object obj, PropertyInfo property, VisualElement container, string objName)
        {
            List<object> sourceList = new List<object>();
            var elementType = property.PropertyType.GetElementType();
            
            var listView = new ListView(sourceList)
            {
                virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight,
                showFoldoutHeader = true,
                headerTitle = objName,
                showAddRemoveFooter = true,
                makeItem = () => new VisualElement(),
                bindItem = (element, i) =>
                {
                    element.Clear();
                    
                    if (elementType == typeof(string))
                        sourceList[i] = string.Empty;
                    else
                        sourceList[i] = Activator.CreateInstance(elementType!);
                    
                    var foldout = new Foldout { text = $"Element {i}", value = false };
                    CreateFieldsForObject(foldout.contentContainer, sourceList[i]);
                    element.Add(foldout);
                    
                    updateUnderlyingArray();
                },
                destroyItem = _ =>
                {
                    updateUnderlyingArray();
                },
                selectionType = SelectionType.None,
                reorderable = true,
                reorderMode = ListViewReorderMode.Animated,
                showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly
            };
            
            container.Add(listView);

            void updateUnderlyingArray()
            {
                Array destinationArray = Array.CreateInstance(elementType!, sourceList.Count);
                Array.Copy(sourceList.ToArray(), destinationArray, destinationArray.Length);
                
                property.SetValue(obj, destinationArray);
            }
        }

        private void SetupNewSubObjectField(object obj, PropertyInfo property, VisualElement container, string objName)
        {
            var subContainer = new Foldout
            {
                text = objName
            };
            container.Add(subContainer);

            var subObject = property.GetValue(obj) 
                            ?? Activator.CreateInstance(property.PropertyType);
            property.SetValue(obj, subObject);

            CreateFieldsForObject(subContainer.contentContainer, subObject);
        }

        private TField SetupNewField<TField, TValue>(object obj, PropertyInfo propertyInfo, VisualElement parent,
            string objName) where TField : BaseField<TValue>, new()
        {
            var field = new TField();

            if (typeof(TValue) == typeof(string))
                field.value = (TValue)propertyInfo.GetValue(obj);
            else
                field.value = (TValue)GetValueNotNull(obj, propertyInfo);
            field.RegisterValueChangedCallback(MakeValueChangedCallback<TValue>(obj, propertyInfo));
            field.label = objName;
            parent.Add(field);

            return field;
        }

        private object GetValueNotNull(object obj, PropertyInfo propertyInfo)
        {
            var value = propertyInfo.GetValue(obj);

            if (value != null) 
                return value;
            
            Type valueType = propertyInfo.PropertyType;
            // valueType is Nullable<X>
            return Activator.CreateInstance(valueType.GetGenericArguments().First());
        }

        private EventCallback<ChangeEvent<T>> MakeValueChangedCallback<T>(object obj, PropertyInfo propertyInfo)
        {
            return ev =>
            {
                propertyInfo.SetValue(obj, ev.newValue);
            };
        }

        private static string GetDisplayName(PropertyInfo property)
        {
            return ObjectNames.NicifyVariableName(property.Name);
        }
    }
}
