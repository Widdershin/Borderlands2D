using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D.ECS.Components
{
    class Sprite : Component
    {
        public Texture2D Texture { get; set; }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }

        public Sprite(string texturePath)
        {
            Texture = TextureManager.Get(texturePath);
        }
    }
}
