using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(2, 2);
        private readonly bool ClockWise;
        private Types.Direction Direction;     

        public HandMovingState(AbstractCharacter character, bool clockWise, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            Sprite = new HandSprite();
            ClockWise = clockWise;

            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            if (ClockWise) Direction = Sprint0.Utils.GetNextClockwiseDirection(Direction);
            else Direction = Sprint0.Utils.GetNextClockwiseDirection(Sprint0.Utils.GetOppositeDirection(Direction));
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new HandFrozenState(Character, Direction, ClockWise, frozenForever);
        }

        public override void Move()
        {
            // Already moving
        }

        public override void Unfreeze()
        {
            // Already unfrozen
        }

        public override void Update(GameTime gameTime)
        {
            Character.Position += Sprint0.Utils.DirectionToVector(Direction) * MovementSpeed;
            Sprite.Update();
        }
    }
}
