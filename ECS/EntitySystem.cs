using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS
{
    public abstract class EntitySystem
    {
        protected List<Type> _managedComponentTypes = new List<Type>();
        protected List<Entity> _entities = new List<Entity>();

        protected Entity _entity { get { return _entities.FirstOrDefault(); } }

        internal void AddEntity(Entity e)
        {
            var types = e.ComponentTypes;
            foreach (var type in _managedComponentTypes.Where(type => !types.Contains(type)))
                throw new ArgumentException("Entity doesn't contain required Component " + type, "e");
            _entities.Add(e);
        }

        internal void RemoveEntity(Entity e)
        {
            _entities.Remove(e);
        }

        public abstract void Update(GameTime time);
    }
}
