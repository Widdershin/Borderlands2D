using System;
using System.Linq;
using System.Collections.Generic;

namespace Borderlands2D.ECS
{
    public class Entity
    {
        public List<Component> Components { get; private set; }
        public List<Type> ComponentTypes { get { return Components.Select(comp => comp.GetType()).ToList(); } } 

        public Entity()
        {
            Components = new List<Component>();
        }

        public T GetComponent<T>() where T : Component
        {
            var type = typeof (T);
            return (T)Components.FirstOrDefault(comp => comp.GetType() == type);
        }
    }
}