using Borderlands2D.Input.InputHandlers;

namespace Borderlands2D.Input
{
    internal class Input
    {
        private static IInputHandler _inputHandler;

        public static IInputHandler InputHandler
        {
            set { _inputHandler = value; }
        }

        public static bool IsActive(Inputs input)
        {
            return _inputHandler.IsActive(input);
        }
    }
}