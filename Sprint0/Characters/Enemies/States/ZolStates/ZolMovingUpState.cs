using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.ZolStates
{
    public class ZolMovingUpState : AbstractCharacterState
    {
        private Zol Zol;
        private Types.Direction StateDirection;
        private Vector2 DirectionVector;
        public ZolMovingUpState(Zol zol)
        {
            Zol = zol;
            StateDirection = Types.Direction.UP;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new ZolSprite();
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(StateDirection);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Zol.State = new ZolMovingLeftState(Zol);
                    break;
                case Types.Direction.RIGHT:
                    Zol.State = new ZolMovingRightState(Zol);
                    break;
                case Types.Direction.DOWN:
                    Zol.State = new ZolMovingDownState(Zol);
                    break;
            }
        }

        public override void Freeze()
        {
            Zol.State = new ZolFrozenState(Zol, StateDirection);
        }

        public override void Move()
        {
            Zol.Position += DirectionVector * Zol.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
