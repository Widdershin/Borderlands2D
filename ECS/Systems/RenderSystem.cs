using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Borderlands2D.ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D.ECS.Systems
{
    class RenderSystem : EntitySystem
    {
        private static RenderSystem instance;
        public static RenderSystem Get { get { return instance; } }

        public RenderSystem()
        {
            _managedComponentTypes.Add(typeof(Position));
            _managedComponentTypes.Add(typeof(Sprite));
            SystemsRegistry.Register(this, _managedComponentTypes.ToArray());
            instance = this;
        }

        public override void Update(GameTime time)
        {
        }
        
        private struct RenderWrapper
        {
            public Texture2D Texture;
            public Entity Entity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (
                 var wrapper in
                     _entities.Select(e => new RenderWrapper { Texture = e.GetComponent<Sprite>().Texture, Entity = e }).
                         OrderBy(wrapper => wrapper.Texture))
                spriteBatch.Draw(wrapper.Texture, wrapper.Entity.GetComponent<Position>().Location, Color.White);
        }
    }
}
