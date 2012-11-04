using System;
using Borderlands2D.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D
{
    public class Player : IEntity
    {
        private const float Speed = 2f;
        private float _rotation;
        private Vector2 SpriteOffset = new Vector2(16, 32);
        

        private Vector2 _position;

        public Player(Vector2 position)
        {
            _position = position;
            Texture = TextureManager.Get("Player");
        }

        #region IEntity Members

        public Vector2 Position
        {
            get { return _position; }
        }

        public Texture2D Texture { get; private set; }

        public void Update(GameTime time)
        {
            if (InputState.IsActive(Inputs.Forward))
                _position.Y -= Speed;

            if (InputState.IsActive(Inputs.Back))
                _position.Y += Speed;

            if (InputState.IsActive(Inputs.Left))
            {
                _position.X -= Speed;
            }

            if (InputState.IsActive(Inputs.Right))
                _position.X += Speed;

            MouseState ms = Mouse.GetState();
<<<<<<< HEAD
            double mx = ms.Y - Position.Y;
            double my = ms.X - Position.X;
            Rotation = (float)Math.Atan2(mx, my);
=======
            Double mx = ms.Y - Position.Y;
            Double my = ms.X - Position.X;
            _rotation = (float)Math.Atan2(mx, my);
>>>>>>> 58ea5e79724e3246280bc527fa70e43e61109230
        }

        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, _rotation, SpriteOffset, new Vector2(1, 1), SpriteEffects.None, 0f);
        }
    }
}