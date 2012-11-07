using System;
using System.Linq;
using System.Collections.Generic;

namespace Borderlands2D.ECS
{
    public class Entity
    {
        public List<IComponent> Components { get; private set; }
        public List<Type> ComponentTypes { get { return Components.Select(comp => comp.GetType()).ToList(); } } 

        public Entity()
        {
            Components = new List<IComponent>();
        }

        public T GetComponent<T>() where T : IComponent
        {
            var type = typeof (T);
            return (T)Components.FirstOrDefault(comp => comp.GetType() == type);
        }
    }
}