using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Borderlands2D.ECS.Components;
using Borderlands2D.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D.ECS.Systems
{
    public class PlayerSystem : EntitySystem
    {
        private const int Speed = 2;

        public PlayerSystem()
        {
            _managedComponentTypes.Add(typeof(PlayerComponent));
            SystemsRegistry.Register(this, _managedComponentTypes.ToArray());
        }

        public override void Update(GameTime time)
        {
            var velocity = _entity.GetComponent<Velocity>();
            var rotation = _entity.GetComponent<Rotation>();
            var position = _entity.GetComponent<Position>();
            velocity.Vector = new Vector2(0, 0);

            if (InputState.IsActive(Inputs.Forward))
                velocity.Y = -Speed;

            if (InputState.IsActive(Inputs.Back))
                velocity.Y = Speed;

            if (InputState.IsActive(Inputs.Left))
            {
                velocity.X = -Speed;
            }

            if (InputState.IsActive(Inputs.Right))
                velocity.X = Speed;

            var ms = Mouse.GetState();
            double mx = ms.Y - position.Y;
            double my = ms.X - position.X;
            rotation.Degrees = (float)Math.Atan2(mx, my);
        }
    }
}
