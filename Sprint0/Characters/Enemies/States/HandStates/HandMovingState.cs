using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.States.BatStates;
using Sprint0.Characters.States.HandStates;
using Sprint0.Characters.Utils;
using Sprint0.GameModes;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandMovingState : AbstractCharacterState
    {
        private static readonly Vector2 MovementSpeed = new(1, 1);
        private readonly bool Clockwise;
        private Types.Direction Direction;     

        public HandMovingState(AbstractCharacter character, Types.Direction direction = Types.Direction.NO_DIRECTION,
            bool clockwise = false) : base(character)
        {
            Clockwise = clockwise;

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
            if (Clockwise) Direction = CharacterUtils.GetNextClockwiseDirection(Direction);
            else Direction = CharacterUtils.GetNextClockwiseDirection(Sprint0.Utils.GetOppositeDirection(Direction));

            if (Direction == (Character as Hand).OriginalDirection) (Character as Hand).ShouldBeKilled = true;
        }

        public override void Draw(SpriteBatch sb, Vector2 position, Color color)
        {
            if ((Character as Hand).PlayerSprite != null) (Character as Hand).PlayerSprite.Draw(sb, position, color,
                Sprint0.Utils.WallLayerDepth + 0.02f);
            Character.Sprite.Draw(sb, position, color, Sprint0.Utils.WallLayerDepth + 0.01f);
        }

        public override void Freeze(bool frozenForever)
        {
            Character.State = new HandFrozenState(Character, Direction, Clockwise, frozenForever);
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            if (inCurrentRoom) Character.State = new HandGameModeTransitionState(Character, oldGameMode, newGameMode, Direction, Clockwise);
            else Character.Sprite = newGameMode.GetHandSprite(this, Direction, Clockwise);
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
