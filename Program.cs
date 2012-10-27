#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Borderlands2D
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        private static Borderlands2D game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            game = new Borderlands2D();
            game.Run();
        }
    }
}
