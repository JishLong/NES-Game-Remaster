using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingState : AbstractCharacterState
    {
        private readonly static ISprite[] Sprites = {
            new RedGoriyaUpSprite(), new RedGoriyaDownSprite(), new RedGoriyaLeftSprite(), new RedGoriyaRightSprite()
        };

        private static readonly Vector2 MovementSpeed = new(1.5f, 1.5f);
        private Types.Direction Direction;

        public RedGoriyaMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            Sprite = Sprites[(int)direction];

            if (direction != Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOmniDirection(Types.Direction.NO_DIRECTION);
        }

        public override void Attack()
        {
            Character.State = new RedGoriyaAttackingState(Character, Direction);
        }

        public override void Move()
        {
            // Nothing here!
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new RedGoriyaFrozenState(Character, Direction, frozenForever);
        }

        public override void ChangeDirection()
        {
            Direction = CharacterUtils.RandOrthogDirection(Direction);
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
