using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class BatMovingDownLeftState : AbstractCharacterState
    {
        private readonly Bat Bat;
        private readonly Types.Direction StateDirection;
        private readonly Vector2 DirectionVector;

        public BatMovingDownLeftState(Bat bat)
        {
            Bat = bat;
            StateDirection = Types.Direction.DOWNLEFT;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new BatSprite();

        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOmniDirection(StateDirection);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Bat.State = new BatMovingLeftState(Bat);
                    break;
                case Types.Direction.UPLEFT:
                    Bat.State = new BatMovingUpLeftState(Bat);
                    break;
                case Types.Direction.UP:
                    Bat.State = new BatMovingUpState(Bat);
                    break;
                case Types.Direction.UPRIGHT:
                    Bat.State = new BatMovingUpRightState(Bat);
                    break;
                case Types.Direction.RIGHT:
                    Bat.State = new BatMovingRightState(Bat);
                    break;
                case Types.Direction.DOWNRIGHT:
                    Bat.State = new BatMovingDownRightState(Bat);
                    break;
                case Types.Direction.DOWN:
                    Bat.State = new BatMovingDownState(Bat);
                    break;
            }
        }

        public override void Freeze()
        {
            Bat.State = new BatFrozenState(Bat, StateDirection);
        }

        public override void Move()
        {
            Bat.Position += DirectionVector * Bat.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}