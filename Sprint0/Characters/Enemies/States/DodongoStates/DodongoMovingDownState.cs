using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Enemies.Utils;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingDownState : AbstractCharacterState
    {
        private Dodongo Dodongo;
        private Vector2 DirectionVector = Utils.DirectionToVector(Types.Direction.DOWN);
        private float MovementSpeed = 2f;
        public DodongoMovingDownState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoDownSprite();
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
            Dodongo.State = new DodongoFrozenDownState(Dodongo);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.DOWN);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Dodongo.State = new DodongoMovingLeftState(Dodongo);
                    break;
                case Types.Direction.RIGHT:
                    Dodongo.State = new DodongoMovingRightState(Dodongo);
                    break;
                case Types.Direction.UP:
                    Dodongo.State = new DodongoMovingUpState(Dodongo);
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

