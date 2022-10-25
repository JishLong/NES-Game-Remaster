using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeFacingLeftMovingUpState : AbstractCharacterState
    {
        private readonly Snake Snake;
        private readonly Types.Direction StateDirection;
        private readonly Vector2 DirectionVector;
        private readonly float MovementSpeed = 2f;
        public SnakeFacingLeftMovingUpState(Snake snake)
        {
            Snake = snake;
            StateDirection = Types.Direction.UP;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new SnakeLeftSprite();
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
                case Types.Direction.RIGHT:
                    Snake.State = new SnakeMovingRightState(Snake);
                    break;
                case Types.Direction.LEFT:
                    Snake.State = new SnakeMovingLeftState(Snake);
                    break;
                case Types.Direction.DOWN:
                    Snake.State = new SnakeFacingLeftMovingDownState(Snake);
                    break;
            }
        }

        public override void Freeze()
        {
            Snake.State = new SnakeFrozenLeftState(Snake,StateDirection);
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
