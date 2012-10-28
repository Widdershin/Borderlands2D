using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D.Input
{
    class Inputs
    {
        public static InputMethod Forward = new InputMethod(Keys.W);
        public static InputMethod Back = new InputMethod(Keys.S);
        public static InputMethod Left = new InputMethod(Keys.A);
        public static InputMethod Right = new InputMethod(Keys.D);
    }
}
