using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Characters.Utils;
using Sprint0.Sprites;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingState : AbstractCharacterState
    {
        private readonly static ISprite[] Sprites = {
            new DodongoUpSprite(), new DodongoDownSprite(), new DodongoLeftSprite(), new DodongoRightSprite()
        };

        private static readonly Vector2 MovementSpeed = new(2, 2);
        private Types.Direction Direction;

        public DodongoMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            Character = character;
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);

            Sprite = Sprites[(int)Direction];
        }

        public override void Attack()
        {
            // Do nothing. (No Attack state)
        }

        public override void Move()
        {
            // Already moving
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new DodongoFrozenState(Character, Direction, frozenForever);
        }

        public override void ChangeDirection()
        {
            Direction = CharacterUtils.RandOrthogDirection(Direction);
            Sprite = Sprites[(int)Direction];
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

