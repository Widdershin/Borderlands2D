using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS.Components
{
    internal class Position : IComponent
    {
        public Vector2 Location;

        public Position(Vector2 loc)
        {
            Location = loc;
        }

        public Position(int x = -1, int y = -1)
        {
            Location = new Vector2(x, y);
        }

        public float X
        {
            get { return Location.X; }
            set { Location.X = value; }
        }

        public float Y
        {
            get { return Location.Y; }
            set { Location.Y = value; }
        }
    }
}