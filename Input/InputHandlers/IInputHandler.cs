using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Borderlands2D.Input.InputHandlers
{
    interface IInputHandler
    {
        bool IsActive(Inputs input);

        void Update(GameTime time);
    }
}
