using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.RedGoriyaStates;
using Sprint0.Characters.Utils;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(1.5f, 1.5f);
        private Types.Direction Direction;

        public RedGoriyaMovingState(AbstractCharacter character, Direction direction = Direction.NO_DIRECTION) : base(character)
        {
            // If there's a preset direction, use that; if not, pick one at random
            if (direction != Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Direction.NO_DIRECTION);

            character.Sprite ??= RedGoriya.GetSprite(Direction);
        }

        public override void Attack()
        {
            Character.State = new RedGoriyaAttackingState(Character, Direction);
        }


        public override void Freeze(bool frozenForever)
        {
            Character.State = new RedGoriyaFrozenState(Character, Direction, frozenForever);
        }

        public override void ChangeDirection()
        {
            Direction = CharacterUtils.RandOrthogDirection(Direction);
            Character.Sprite = RedGoriya.GetSprite(Direction);
        }

        public override void Unfreeze()
        {
            // Already unfrozen
        }

        public override void Update(GameTime gameTime)
        {
            Character.Position += Sprint0.Utils.DirectionToVector(Direction) * MovementSpeed;
            Character.Sprite.Update();
        }
    }
}
