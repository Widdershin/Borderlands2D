using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Borderlands2D.Input.InputHandlers
{
    interface IInputHandler
    {
        bool IsActive(Inputs input);
    }
}
