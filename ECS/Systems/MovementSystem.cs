using System;
using System.Linq;
using Borderlands2D.ECS.Components;
using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS.Systems
{
    class MovementSystem : EntitySystem
    {

        public MovementSystem()
        {
            _managedComponentTypes.Add(typeof (Position));
            _managedComponentTypes.Add(typeof (Velocity));
            SystemsRegistry.Register(this, _managedComponentTypes.ToArray());
        }

        public override void Update(GameTime time)
        {
            foreach (var position in _entities.Select(e => e.GetComponent<Position>()))
                position.Location = new Vector2(position.Location.X + 1, position.Location.Y);
        }
    }
}
