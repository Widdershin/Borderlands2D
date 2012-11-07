namespace Borderlands2D.ECS.Components
{
    public class Rotation : IComponent
    {
        public float Degrees;

        public Rotation(float degrees = 0)
        {
            Degrees = degrees;
        }
    }
}