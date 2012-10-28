using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D.Input.InputHandlers
{
    internal class KeyBoardAndMouse : IInputHandler
    {
        private KeyboardState _kbState;
        private MouseState _mState;
        private int _oldScrollWheelValue;

        #region IInputHandler Members

        public bool IsActive(InputMethod input)
        {
            switch (input.Type)
            {
                case InputMethod.InputType.Keyboard:
                    return _kbState.IsKeyDown(input.Key);

                case InputMethod.InputType.Mouse:
                    switch (input.MouseButton)
                    {
                        case InputMethod.MouseButtons.Left:
                            return (int) _mState.LeftButton == 1;
                        case InputMethod.MouseButtons.Right:
                            return (int) _mState.RightButton == 1;
                        case InputMethod.MouseButtons.Middle:
                            return (int) _mState.MiddleButton == 1;
                        case InputMethod.MouseButtons.ScrollUp:
                            return _oldScrollWheelValue < _mState.ScrollWheelValue;
                        case InputMethod.MouseButtons.ScrollDown:
                            return _mState.ScrollWheelValue < _oldScrollWheelValue;

                        default:
                            return false;
                    }
            }
            return false;
        }

        public void Update(GameTime time)
        {
            if (_mState != null)
                _oldScrollWheelValue = _mState.ScrollWheelValue;
            _kbState = Keyboard.GetState();
            _mState = Mouse.GetState();
        }

        #endregion
    }
}