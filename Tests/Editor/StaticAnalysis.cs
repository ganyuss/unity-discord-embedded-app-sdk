using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DiscordActivitySdk.Messages.Events;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Tests.Editor
{
    public class StaticAnalysis
    {
        private Assembly RuntimeDiscordSdkAssembly;
        
        [SetUp]
        public void SetUp()
        {
            RuntimeDiscordSdkAssembly = Assembly.GetAssembly(typeof(DiscordSdk));
        }
        
        [Test]
        public void CommandPropertiesHaveGetPreserved()
        {
            List<Type> typesMissingSetPreserved = new List<Type>();
            
            foreach (var commandType in RuntimeDiscordSdkAssembly.GetTypes()
                         .Where(t => t.Namespace == "DiscordActivitySdk.Messages.Commands"
                         && ! IsStatic(t)))
            {
                foreach (var property in commandType.GetProperties())
                {
                    if (property.DeclaringType != commandType)
                        continue;
                    
                    if (HasAttribute<JsonIgnoreAttribute>(property))
                        continue;
                    
                    if (property.SetMethod != null
                        && ! HasAttribute<PreserveAttribute>(property.GetMethod))
                    {
                        typesMissingSetPreserved.Add(commandType);
                        break;
                    }
                }
            }
            
            if (typesMissingSetPreserved.Count > 0)
            {
                var typesString = string.Join(", ", typesMissingSetPreserved.Select(t => t.Name)); 
                Assert.Fail($"Discord command(s) missing preserve attribute on property getter:\n{typesString}");
            }
        }
        
        [Test]
        public void EventArePreserved()
        {
            List<Type> typesMissingPreserved = new List<Type>();
            
            foreach (var eventType in RuntimeDiscordSdkAssembly.GetTypes()
                         .Where(t => (t.Namespace == "DiscordActivitySdk.Messages.Events"
                                     || t.Namespace == "DiscordActivitySdk.Messages.Events.Responses")
                                     && ! IsStatic(t)))
            {
                if (eventType.IsAbstract || eventType == typeof(DiscordEvent))
                    continue;
                
                if (!typeof(DiscordEvent).IsAssignableFrom(eventType))
                    continue;
                
                if (! HasAttribute<PreserveAttribute>(eventType))
                    typesMissingPreserved.Add(eventType);
            }
            
            if (typesMissingPreserved.Count > 0)
            {
                var typesString = string.Join(", ", typesMissingPreserved.Select(t => t.Name)); 
                Assert.Fail($"Discord event(s) missing preserve attribute:\n{typesString}");
            }
        }
        
        [Test]
        public void EventPropertiesHaveSetPreserved()
        {
            List<Type> typesMissingSetPreserved = new List<Type>();
            
            foreach (var eventType in RuntimeDiscordSdkAssembly.GetTypes()
                         .Where(t => (t.Namespace == "DiscordActivitySdk.Messages.Events"
                                      || t.Namespace == "DiscordActivitySdk.Messages.Events.Responses")
                                      && ! IsStatic(t)))
            {
                foreach (var property in eventType.GetProperties())
                {
                    if (property.DeclaringType != eventType)
                        continue;
                    
                    if (HasAttribute<JsonIgnoreAttribute>(property))
                        continue;
                    
                    if (property.SetMethod != null
                        && ! HasAttribute<PreserveAttribute>(property.SetMethod))
                    {
                        typesMissingSetPreserved.Add(eventType);
                        break;
                    }
                }
            }
            
            if (typesMissingSetPreserved.Count > 0)
            {
                var typesString = string.Join(", ", typesMissingSetPreserved.Select(t => t.Name)); 
                Assert.Fail($"Discord event(s) missing preserve attribute:\n{typesString}");
            }
        }
        
        [Test]
        public void ModelPropertiesHaveGetAndSetPreserved()
        {
            List<Type> typesMissingSetPreserved = new List<Type>();
            
            foreach (var commandType in RuntimeDiscordSdkAssembly.GetTypes()
                         .Where(t => t.Namespace == "DiscordActivitySdk.Messages.Model"
                                     && ! IsStatic(t)))
            {
                foreach (var property in commandType.GetProperties())
                {
                    if (property.DeclaringType != commandType)
                        continue;
                    
                    if (HasAttribute<JsonIgnoreAttribute>(property))
                        continue;
                    
                    if (property.SetMethod != null
                        && property.GetMethod != null
                        && (! HasAttribute<PreserveAttribute>(property.SetMethod)
                        || ! HasAttribute<PreserveAttribute>(property.GetMethod)))
                    {
                        typesMissingSetPreserved.Add(commandType);
                        break;
                    }
                }
            }
            
            if (typesMissingSetPreserved.Count > 0)
            {
                var typesString = string.Join(", ", typesMissingSetPreserved.Select(t => t.Name)); 
                Assert.Fail($"Model class(es) missing preserve attribute on property setter or getter:\n{typesString}");
            }
        }
        
        [Test]
        public void ModelArePreserved()
        {
            List<Type> typesMissingPreserved = new List<Type>();
            
            foreach (var modelType in RuntimeDiscordSdkAssembly.GetTypes()
                         .Where(t => t.Namespace == "DiscordActivitySdk.Messages.Model"
                                     && ! IsStatic(t)
                                     && ! t.IsEnum))
            {
                if (! HasAttribute<PreserveAttribute>(modelType))
                    typesMissingPreserved.Add(modelType);
            }
            
            if (typesMissingPreserved.Count > 0)
            {
                var typesString = string.Join(", ", typesMissingPreserved.Select(t => t.Name)); 
                Assert.Fail($"Model class(es) missing preserve attribute:\n{typesString}");
            }
        }

        private bool HasAttribute<T>(MemberInfo member) where T : Attribute
        {
            return member.CustomAttributes.Any(attr => attr.AttributeType == typeof(T));
        }

        private static bool IsStatic(Type t)
        {
            return t.IsAbstract && t.IsSealed;
        }
    }
}