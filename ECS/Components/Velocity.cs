using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS.Components
{
    class Velocity : IComponent
    {
        public Vector2 Vector;

        public float X
        {
            get { return Vector.X; }
            set { Vector.X = value; }
        }

        public float Y
        {
            get { return Vector.Y; }
            set { Vector.Y = value; }
        }

        public Velocity(Vector2 vector)
        {
            Vector = vector;
        }

        public Velocity(int x, int y)
        {
            Vector = new Vector2(0, 0);
        }

        public Velocity() : this(0, 0)
        {
            
        }
    }
}
