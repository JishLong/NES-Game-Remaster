using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Utils;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingUpState : AbstractCharacterState
    {
        private readonly Dodongo Dodongo;
        private readonly Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.UP);
        private readonly float MovementSpeed = 2f;
        public DodongoMovingUpState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoUpSprite();
        }
        public override void Attack()
        {
            // Do nothing. (No Attack state)
        }
        public override void Move()
        {
            Dodongo.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Dodongo.State = new DodongoFrozenUpState(Dodongo);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.UP);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Dodongo.State = new DodongoMovingLeftState(Dodongo);
                    break;
                case Types.Direction.RIGHT:
                    Dodongo.State = new DodongoMovingRightState(Dodongo);
                    break;
                case Types.Direction.DOWN:
                    Dodongo.State = new DodongoMovingDownState(Dodongo);
                    break;
            }
        }
        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}

