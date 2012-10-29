using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D
{
    interface IEntity
    {
        Vector2 Position { get; }
        Texture2D Texture { get; }

        void Update(GameTime time);
    }
}
