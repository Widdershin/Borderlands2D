using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D.Input
{
    class InputMethod
    {
        public enum InputType
        {
            Keyboard,
            Mouse,
            Touch,
        }

        public enum MouseButtons
        {
            Left,
            Right,
            Middle,
            ScrollUp,
            ScrollDown
        }

        public Keys Key { get; private set; }
        public MouseButtons MouseButton { get; private set; }
        public Rectangle TouchRegion { get; private set; }
        public InputType Type { get; private set; }

        public InputMethod(Keys key)
        {
            Key = key;
            Type = InputType.Keyboard;
        }

        public InputMethod(MouseButtons button)
        {
            MouseButton = button;
            Type = InputType.Mouse;
        }

        public InputMethod(Rectangle region)
        {
            TouchRegion = region;
            Type = InputType.Touch;
        }
    }
}
