using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeMovingRightState: AbstractCharacterState
    {
        private Snake Snake;
        private Types.Direction StateDirection;
        private Vector2 DirectionVector;
        private float MovementSpeed = 2f;
        public SnakeMovingRightState(Snake snake)
        {
            Snake = snake;
            StateDirection = Types.Direction.RIGHT;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new SnakeRightSprite();
        }

        public override void Attack()
        {
            // Does not have an attack.
        }

        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(StateDirection);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Snake.State = new SnakeMovingLeftState(Snake);
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
