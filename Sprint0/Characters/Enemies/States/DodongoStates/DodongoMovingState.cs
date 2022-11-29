using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.States.DodongoStates;
using Sprint0.GameModes;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(2, 2);
        private Types.Direction Direction;

        public DodongoMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            // If there's a preset direction, use that; if not, pick one at random
            if (direction != Types.Direction.NO_DIRECTION) Direction = direction;
            else Direction = CharacterUtils.RandOrthogDirection(Types.Direction.NO_DIRECTION);

            character.Sprite ??= Dodongo.GetSprite(this, Direction);
        }

        public override void Attack()
        {
            // Do nothing. (No Attack state)
        }

        public override void ChangeDirection()
        {
            Direction = CharacterUtils.RandOrthogDirection(Direction);
            Character.Sprite = Dodongo.GetSprite(this, Direction);
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new DodongoFrozenState(Character, Direction, frozenForever);
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            if (inCurrentRoom) Character.State = new DodongoGameModeTransitionState(Character, oldGameMode, newGameMode, Direction);
            else Character.Sprite = newGameMode.GetDodongoSprite(this, Direction);
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
