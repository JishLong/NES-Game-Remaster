using Microsoft.Xna.Framework;
using Sprint0.GameModes;
using Sprint0.Characters.Enemies.States.BatStates;
using Sprint0.Characters.Enemies.AquamentusStates;

namespace Sprint0.Characters.States.AquamentusStates
{
    public class AquamentusGameModeTransitionState : AbstractCharacterState
    {
        private static readonly int FlashingFrames = 7;
        private static readonly int NumFlashes = 6;
        private readonly IGameMode OldGameMode;
        private readonly IGameMode NewGameMode;
        private readonly Types.Direction Direction;

        private int FramesPassed;
        private int FlashesPassed;

        public AquamentusGameModeTransitionState(AbstractCharacter character, IGameMode oldGameMode, IGameMode newGameMode,
            Types.Direction direction = Types.Direction.NO_DIRECTION) : base(character)
        {
            OldGameMode = oldGameMode;
            NewGameMode = newGameMode;
            Direction = direction;

            character.Sprite = oldGameMode.GetAquamentusSprite(this, direction);
            character.GameMode = newGameMode.Type;

            FramesPassed = 0;
            FlashesPassed = 0;
        }

        public override void Attack()
        {
            // Nothing happens; gamemode transition effect must complete itself
        }

        public override void ChangeDirection()
        {
            // Nothing happens; gamemode transition effect must complete itself
        }

        public override void Freeze(bool frozenForever)
        {
            // Nothing happens; gamemode transition effect must complete itself
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            // Already transitioning gamemodes
        }

        public override void Unfreeze()
        {
            // Nothing happens; gamemode transition effect must complete itself
        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed++;

            if (FramesPassed % FlashingFrames == 0)
            {
                if (FlashesPassed % 2 == 0) Character.Sprite = NewGameMode.GetAquamentusSprite(this, Direction);
                else Character.Sprite = OldGameMode.GetAquamentusSprite(this, Direction);

                FlashesPassed++;
                if (FlashesPassed > NumFlashes)
                {
                    Character.Sprite = NewGameMode.GetAquamentusSprite(this, Direction);
                    Character.State = new AquamentusMovingState(Character, Direction);
                }
            }
        }
    }
}
