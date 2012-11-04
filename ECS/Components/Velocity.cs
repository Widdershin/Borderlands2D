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

        public Velocity()
        {
            Vector = new Vector2(0, 0);
        }
    }
}
