using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class BatMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(2, 2);
        private Types.Direction Direction;

        public BatMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            // If there's a preset direction, use that; if not, pick one at random
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOmniDirection(Types.Direction.NO_DIRECTION);
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Direction = CharacterUtils.RandOmniDirection(Direction);
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new BatFrozenState(Character, Direction, frozenForever);
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
