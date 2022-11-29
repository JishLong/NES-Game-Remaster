using Microsoft.Xna.Framework;
using Sprint0.Characters.States.BatStates;
using Sprint0.Characters.States.ZolStates;
using Sprint0.Characters.Utils;
using Sprint0.GameModes;

namespace Sprint0.Characters.Enemies.States.ZolStates
{
    public class ZolMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(1, 1);
        private Types.Direction Direction;

        public ZolMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
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
            Direction = CharacterUtils.RandOrthogDirection(Direction);
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new ZolFrozenState(Character, Direction, frozenForever);
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            if (inCurrentRoom) Character.State = new ZolGameModeTransitionState(Character, oldGameMode, newGameMode, Direction);
            else Character.Sprite = newGameMode.GetZolSprite(this, Direction);
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
