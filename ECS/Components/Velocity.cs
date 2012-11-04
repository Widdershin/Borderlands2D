using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS.Components
{
    class Velocity : Component
    {
        public Vector2 Vector { get; set; }

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
