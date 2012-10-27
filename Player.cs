using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D
{
    public class Player
    {
        public Vector2 Position;
        public String SpritePath;

        Texture2D sprite;
        float speed = 2f;

        public Player(Vector2 position, String spritePath)
        {
            Position = position;
            SpritePath = spritePath;
        }

        public void LoadContent(ContentManager contentManager)
        {
            sprite = contentManager.Load<Texture2D>(SpritePath);
        }

        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.W))
            {
                Position.Y -= speed;
            }

            if (ks.IsKeyDown(Keys.S))
            {
                Position.Y += speed;
            }

            if (ks.IsKeyDown(Keys.A))
            {
                Position.X -= speed;
            }

            if (ks.IsKeyDown(Keys.D))
            {
                Position.X += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Position, Color.White);
        }

    }
}
