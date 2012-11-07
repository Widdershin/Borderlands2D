using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Borderlands2D.Entities;

namespace Borderlands2D.ECS
{
    sealed class EntityRegistry
    {
        private static readonly HashSet<Type> REGISTERED_TYPES = new HashSet<Type>(); 

        public static T CreateEntity<T>(params object[] args) where T : Entity
        {
            var type = typeof (T);
            if(!REGISTERED_TYPES.Contains(type))
                throw new ArgumentException("Type is not registered as an entity!");
            var instance = (T)Activator.CreateInstance(typeof(T), args);
            SystemsRegistry.AddEntity(instance);
            return instance;
        }

        public static void Register(Type e)
        {
            REGISTERED_TYPES.Add(e);
        }
    }
}
