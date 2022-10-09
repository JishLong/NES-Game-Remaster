using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeFrozenRightState: AbstractEnemyState
    {
        private Snake Snake;
        private Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public SnakeFrozenRightState(Snake snake, Direction direction)
        {
            Snake = snake;
            ResumeMovementDirection = direction;
            Sprite = new SnakeRightSprite();
        }

        public override void Attack()
        {
            // Does not have an attack.
        }

        public override void ChangeDirection()
        {
            switch (ResumeMovementDirection)
            {
                case Direction.Right:
                    Snake.State = new SnakeMovingRightState(Snake);
                    break;
                case Direction.Up:
                    Snake.State = new SnakeFacingRightMovingUpState(Snake);
                    break;
                case Direction.Down:
                    Snake.State = new SnakeFacingRightMovingDownState(Snake);
                    break;
            }
        }

        public override void Freeze()
        {
            // Already frozen.
        }

        public override void Move()
        {
            // Cant move while frozen.
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            FrozenTimer += elapsedTime;

            if((FrozenTimer - FrozenDelay) > 0)
            {
                ChangeDirection();
            }
            Sprite.Update();
        }
    }
}
