using Borderlands2D.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Borderlands2D
{
    public class Player : IEntity
    {
        private const float Speed = 2f;

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
                _position.X -= Speed;

            if (InputState.IsActive(Inputs.Right))
                _position.X += Speed;
        }

        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}