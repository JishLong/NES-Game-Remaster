using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(2, 2);
        private readonly bool ClockWise;
        private Types.Direction Direction;     

        public HandMovingState(AbstractCharacter character, bool clockWise, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            ClockWise = clockWise;

            // If there's a preset direction, use that; if not, pick one at random
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            // Note on logic: clockwise and counter-clockwise directions are opposites of each other when you think about it
            if (ClockWise) Direction = CharacterUtils.GetNextClockwiseDirection(Direction);
            else Direction = CharacterUtils.GetNextClockwiseDirection(Sprint0.Utils.GetOppositeDirection(Direction));
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new HandFrozenState(Character, Direction, ClockWise, frozenForever);
        }

        public override void Unfreeze()
        {
            // Already unfrozen!
        }

        public override void Update(GameTime gameTime)
        {
            Character.Position += Sprint0.Utils.DirectionToVector(Direction) * MovementSpeed;
            Character.Sprite.Update();
        }
    }
}
