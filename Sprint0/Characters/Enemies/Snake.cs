﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Behaviors;
using Sprint0.Sprites.Characters.Enemies;
using System.Collections.Generic;
using Sprint0.Sprites;
using System;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies
{
    public class Snake : AbstractEnemy
    {
        private Dictionary<Direction, ISprite> DirectionSprites = new Dictionary<Direction, ISprite>()
        {
            {Direction.Up, new SnakeLeftSprite()},
            {Direction.Down, new SnakeRightSprite()},
            {Direction.Left, new SnakeLeftSprite()},
            {Direction.Right, new SnakeRightSprite()},
        };
        public Snake(Vector2 position, float movementSpeed = 3, Direction direction = Direction.Left)
        {
            // Combat
            Health = 1;

            // Movement
            Direction = direction;
            Position = position;
            MovementBehavior = new OrthogonalMovementBehavior(movementSpeed, Direction);

            // Update related fields
            Sprite = new BatSprite();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            if (!IsFrozen)
            {   
                Position += MovementBehavior.Move(gameTime);
                Direction = MovementBehavior.GetDirection();
                Sprite = DirectionSprites[Direction];
            }
            Sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}