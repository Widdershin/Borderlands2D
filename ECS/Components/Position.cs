using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS.Components
{
    class Position : Component
    {
        public Vector2 Location { get; set; }

        public Position(int x, int y)
        {
            Location = new Vector2(x, y);   
        }

        public Position() : this(-1, -1)
        {
           
        }
    }
}
