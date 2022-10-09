using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeFacingRightMovingDownState: AbstractEnemyState
    {
        private Snake Snake;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        private float MovementSpeed = 2f;
        public SnakeFacingRightMovingDownState(Snake snake)
        {
            Snake = snake;
            StateDirection = Direction.Down;
            DirectionVector = ToVector(StateDirection);
            Sprite = new SnakeRightSprite();
        }

        public override void Attack()
        {
            // Does not have an attack.
        }

        public override void ChangeDirection()
        {
            Direction direction = RandOrthogDirection(StateDirection);
            switch (direction)
            {
                case Direction.Left:
                    Snake.State = new SnakeMovingLeftState(Snake);
                    break;
                case Direction.Right:
                    Snake.State = new SnakeMovingRightState(Snake);
                    break;
                case Direction.Up:
                    Snake.State = new SnakeFacingRightMovingUpState(Snake);
                    break;
            }
        }

        public override void Freeze()
        {
            Snake.State = new SnakeFrozenRightState(Snake, StateDirection);
        }

        public override void Move()
        {
            Snake.Position += DirectionVector * MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
