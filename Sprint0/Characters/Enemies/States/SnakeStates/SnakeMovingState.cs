using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class SnakeMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(2, 2);
        private Types.Direction Direction;

        public SnakeMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);
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
            Character.State = new SnakeFrozenState(Character, Direction, frozenForever);
        }

        public override void Move()
        {
            // Nothing here!
        }

        public override void Unfreeze()
        {
            // Already unfrozen!
        }

        public override void Update(GameTime gameTime)
        {
            Character.Position += Sprint0.Utils.DirectionToVector(Direction) * MovementSpeed;
            Sprite.Update();
        }
    }
}
