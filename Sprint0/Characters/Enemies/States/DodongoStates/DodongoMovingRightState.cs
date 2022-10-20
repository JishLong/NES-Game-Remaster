using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Enemies.Utils;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingRightState : AbstractCharacterState
    {
        private Dodongo Dodongo;
        private Vector2 DirectionVector = Utils.DirectionToVector(Types.Direction.RIGHT);
        private float MovementSpeed = 2f;
        public DodongoMovingRightState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoRightSprite();
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
            Dodongo.State = new DodongoFrozenRightState(Dodongo);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.RIGHT);
            switch (direction)
            {
                case Types.Direction.UP:
                    Dodongo.State = new DodongoMovingUpState(Dodongo);
                    break;
                case Types.Direction.LEFT:
                    Dodongo.State = new DodongoMovingLeftState(Dodongo);
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

