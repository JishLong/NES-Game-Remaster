using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;

namespace Sprint0.Characters.Enemies.States
{
    public class HandMovingState : AbstractCharacterState
    {
        private Types.Direction Direction;
        private readonly bool Clockwise;

        public HandMovingState(AbstractCharacter character, bool clockwise) : base(character) 
        {
            Clockwise = clockwise;
        }

        public override void Attack()
        {
            if (Character.AttackState != null)
            {
                Character.AttackState.SetUp(Direction);
                Character.CurrentState = Character.AttackState;
            }
        }

        public override void ChangeDirection()
        {
            // Note on logic: clockwise and counter-clockwise directions are opposites of each other when you think about it
            if (Clockwise) Direction = CharacterUtils.GetNextClockwiseDirection(Direction);
            else Direction = CharacterUtils.GetNextClockwiseDirection(Sprint0.Utils.GetOppositeDirection(Direction));

            if (Direction == (Character as Hand).OriginalDirection) (Character as Hand).ShouldBeKilled = true;

            Character.SetSprite(Direction);
        }

        public override void Freeze(bool frozenForever)
        {
            if (frozenForever && Character.FrozenForeverState != null)
            {
                Character.FrozenForeverState.SetUp(Direction);
                Character.CurrentState = Character.FrozenForeverState;
            }
            else if (!frozenForever && Character.FrozenTemporarilyState != null)
            {
                Character.FrozenTemporarilyState.SetUp(Direction);
                Character.CurrentState = Character.FrozenTemporarilyState;
            }
        }

        public override void SetUp(Types.Direction direction)
        {
            // If there's a preset direction, use that; if not, pick one at random
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);

            Character.SetSprite(Direction);
        }

        public override void Unfreeze()
        {
            // Already unfrozen!
        }

        public override void Update(GameTime gameTime)
        {
            Character.Position += Sprint0.Utils.DirectionToVector(Direction) * Character.MovementSpeed;
            Character.Sprite.Update();
        }
    }
}
