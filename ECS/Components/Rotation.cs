namespace Borderlands2D.ECS.Components
{
    public class Rotation : IComponent
    {
        public double Degrees;

        public Rotation(double degrees = 0)
        {
            Degrees = degrees;
        }
    }
}