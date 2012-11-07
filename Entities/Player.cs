using System;
using Borderlands2D.ECS;
using Borderlands2D.ECS.Components;
using Borderlands2D.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Borderlands2D.Entities
{
    public class Player : Entity
    {
        
        public Player(Vector2 position)
        {
            Components.Add(new Position(position));
            Components.Add(new Velocity(2, 2));
            Components.Add(new Sprite("Player", new Vector2(16, 32)));
            Components.Add(new Rotation());
            Components.Add(new PlayerComponent());
        }
    }
}