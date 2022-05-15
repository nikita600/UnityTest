using System;
using System.Collections.Generic;

namespace Game
{
    public static class Services
    {
        private static readonly Dictionary<Type, object> Instances = new Dictionary<Type, object>();

        public static void Setup()
        {
            Instances.Clear();
        }
        
        public static void Release()
        {
            Instances.Clear();
        }
        
        public static T Get<T>() where T : class
        {
            var type = typeof(T);
            if (Instances.TryGetValue(type, out var instance))
            {
                return instance as T;
            }
            
            return default;
        }
        
        public static void Register<T>(object instance)
        {
            var type = typeof(T);
            if (Instances.ContainsKey(type))
            {
                throw new Exception("Trying to rigester already registered service of type: " + type.Name);
            }
            
            Instances.Add(type, instance);
        }

        public static void Unregister<T>()
        {
            var type = typeof(T);
            if (!Instances.ContainsKey(type))
            {
                throw new Exception("Trying to unrigester already unregistered service of type: " + type.Name);
            }
            
            Instances.Remove(type);
        }
    }
}


