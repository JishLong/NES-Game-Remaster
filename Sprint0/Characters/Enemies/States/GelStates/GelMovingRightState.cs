using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.GelStates
{
    public class GelMovingRightState: AbstractCharacterState
    {
        private readonly Gel Gel;
        private readonly Types.Direction StateDirection;
        private readonly Vector2 DirectionVector;

        public GelMovingRightState(Gel gel)
        {
            Gel = gel;
            StateDirection = Types.Direction.RIGHT;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new GelSprite();
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
                    Gel.State = new GelMovingLeftState(Gel);
                    break;
                case Types.Direction.DOWN:
                    Gel.State = new GelMovingDownState(Gel);
                    break;
                case Types.Direction.UP:
                    Gel.State = new GelMovingUpState(Gel);
                    break;
            }
        }

        public override void Freeze()
        {
            Gel.State = new GelFrozenState(Gel, StateDirection);
        }

        public override void Move()
        {
            Gel.Position += DirectionVector * Gel.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
