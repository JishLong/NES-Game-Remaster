using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeFrozenRightState: AbstractCharacterState
    {
        private readonly Snake Snake;
        private readonly Types.Direction ResumeMovementDirection;
        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public SnakeFrozenRightState(Snake snake, Types.Direction direction)
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
                case Types.Direction.RIGHT:
                    Snake.State = new SnakeMovingRightState(Snake);
                    break;
                case Types.Direction.UP:
                    Snake.State = new SnakeFacingRightMovingUpState(Snake);
                    break;
                case Types.Direction.DOWN:
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
