using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;

namespace Sprint0.Characters.Enemies.States.SnakeStates
{
    public class SnakeMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(2, 2);
        private Types.Direction Direction;

        public SnakeMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            // If there's a preset direction, use that; if not, pick one at random
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);

            character.Sprite ??= Snake.GetSprite(Direction);
        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Direction = CharacterUtils.RandOrthogDirection(Direction);

            // If the snake moves vertically, they retain the sprite they had while they were moving horizontally
            if (Direction == Types.Direction.LEFT) Character.Sprite = Snake.GetSprite(Types.Direction.LEFT);
            else if (Direction == Types.Direction.RIGHT) Character.Sprite = Snake.GetSprite(Types.Direction.RIGHT);
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new SnakeFrozenState(Character, Direction, frozenForever);
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
