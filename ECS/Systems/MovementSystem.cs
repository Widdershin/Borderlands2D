using System.Linq;
using Borderlands2D.ECS.Components;
using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS.Systems
{
    internal class MovementSystem : EntitySystem
    {
        public MovementSystem()
        {
            _managedComponentTypes.Add(typeof (Position));
            _managedComponentTypes.Add(typeof (Velocity));
            SystemsRegistry.Register(this, _managedComponentTypes.ToArray());
        }

        public override void Update(GameTime time)
        {
            foreach ( var components in _entities.Select(e => new {Position = e.GetComponent<Position>(), Velocity = e.GetComponent<Velocity>()})
                                                 .Where(comps => comps.Velocity.Vector != new Vector2(0, 0)))
            {
                var normalized = components.Velocity.Vector.Normalized();
                components.Position.Location = new Vector2(components.Position.X + normalized.X,
                                                           components.Position.Y + normalized.Y);
            }
        }
    }
}