using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D.ECS.Components
{
    class Sprite : IComponent
    {
        public Texture2D Texture { get; set; }
        public Vector2 Offset;

        public Sprite(Texture2D texture, Vector2 offset)
        {
            Texture = texture;
            Offset = offset;
        }

        public Sprite(Texture2D texture) : this(texture, new Vector2(0, 0))
        {
            
        }

        public Sprite(string texturePath, Vector2 offset)
        {
            Texture = TextureManager.Get(texturePath);
            Offset = offset;
        }

        public Sprite(string texturePath) : this(texturePath, new Vector2(0, 0))
        {
            
        }
    }
}
