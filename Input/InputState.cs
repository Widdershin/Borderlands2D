using Borderlands2D.Input.InputHandlers;
using Microsoft.Xna.Framework;

namespace Borderlands2D.Input
{
    internal class InputState
    {
        private static IInputHandler _inputHandler;

        public static IInputHandler InputHandler
        {
            set { _inputHandler = value; }
        }

        public static bool IsActive(InputMethod input)
        {
            return _inputHandler.IsActive(input);
        }

        public static void Update(GameTime time)
        {
            _inputHandler.Update(time);
        }
    }
}