using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Borderlands2D.ECS
{
    sealed class EntityRegistry
    {
        private static readonly HashSet<Type> REGISTERED_TYPES = new HashSet<Type>(); 

        public static T CreateEntity<T>()
        {
            var type = typeof (T);
            if(!REGISTERED_TYPES.Contains(type))
                throw new ArgumentException("Type is not registered as an entity!");
            return Activator.CreateInstance<T>();
        }
    }
}
