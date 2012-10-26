using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Borderlands2D
{
    public class Player
    {
        public Vector2 position { get; set; }
        public String spritePath { get; set; }

        Texture2D playerSprite;

        public void LoadContent(ContentManager contentManager)
        {
            playerSprite = contentManager.Load<Texture2D>(spritePath);
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerSprite, position, Color.White);
        }

    }
}
