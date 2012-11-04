using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Borderlands2D.ECS;
using Borderlands2D.ECS.Components;

namespace Borderlands2D.Entities
{
    class TestThingy : Entity
    {
        static TestThingy()
        {
            EntityRegistry.Register(typeof(TestThingy));
        }

        public TestThingy()
        {
            Components.Add(new Position(50, 50));
            Components.Add(new Velocity(1, 1));
            Components.Add(new Sprite("Player"));
        }
    }
}
