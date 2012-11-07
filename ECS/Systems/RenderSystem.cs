using System.Linq;
using Borderlands2D.ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D.ECS.Systems
{
    internal class RenderSystem : EntitySystem
    {
        private static RenderSystem _instance;

        public RenderSystem()
        {
            _managedComponentTypes.Add(typeof (Position));
            _managedComponentTypes.Add(typeof (Sprite));
            SystemsRegistry.Register(this, _managedComponentTypes.ToArray());
            _instance = this;
        }

        public static RenderSystem Get
        {
            get { return _instance; }
        }

        public override void Update(GameTime time)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var wrapper in _entities.Select(e => new {Sprite = e.GetComponent<Sprite>(), Entity = e})
                                             .OrderBy(wrapper => wrapper.Sprite.Texture))
            {
                var rotationComp = wrapper.Entity.GetComponent<Rotation>();
                var rotation = rotationComp == null ? 0 : rotationComp.Degrees;
                spriteBatch.Draw(wrapper.Sprite.Texture, wrapper.Entity.GetComponent<Position>().Location, null,
                                 Color.White, rotation, wrapper.Sprite.Offset, new Vector2(1, 1), SpriteEffects.None, 0f);
            }
        }
    }
}