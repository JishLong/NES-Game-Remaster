using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeMovingLeftState: AbstractEnemyState
    {
        private Snake Snake;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        private float MovementSpeed = 2f;
        public SnakeMovingLeftState(Snake snake)
        {
            Snake = snake;
            StateDirection = Direction.Left;
            DirectionVector = ToVector(StateDirection);
            Sprite = new SnakeLeftSprite();
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
                case Direction.Right:
                    Snake.State = new SnakeMovingRightState(Snake);
                    break;
                case Direction.Up:
                    Snake.State = new SnakeFacingLeftMovingUpState(Snake);
                    break;
                case Direction.Down:
                    Snake.State = new SnakeFacingLeftMovingDownState(Snake);
                    break;
            }
        }

        public override void Freeze()
        {
            Snake.State = new SnakeFrozenLeftState(Snake, StateDirection);
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
