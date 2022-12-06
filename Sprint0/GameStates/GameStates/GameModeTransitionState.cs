using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Controllers;
using Sprint0.GameModes;
using Sprint0.Input;
using Sprint0.Levels.Utils;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class GameModeTransitionState : AbstractGameState
    {
        private static readonly int NumFlashes = 10;
        private static readonly int FlashFreq = 5;

        private readonly IGameMode OldGameMode;
        private readonly IGameMode NewGameMode;
        private readonly IGameState PlayingState;

        private int FramesPassed;
        private int FlashesPassed;
        private bool IsFlashing;

        public GameModeTransitionState(Game1 game, IGameMode newGameMode) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryTransitionStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            OldGameMode = GameModeManager.GetInstance().GameMode;
            NewGameMode = newGameMode;
            PlayingState = new PlayingState(game);       

            FramesPassed = 0;
            FlashesPassed = 0;
            IsFlashing = false;
        }

        public override void Draw(SpriteBatch sb)
        {
            PlayingState.Draw(sb);

            if (IsFlashing) sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet,
                new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight), ImageMappings.GetInstance().ScreenCover,
                Color.Black * 0.5f, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
        }

        public override void Update(GameTime gameTime)
        {
            if (OldGameMode.Type == NewGameMode.Type) Game.CurrentState = PlayingState;
            else if (FramesPassed == 0 && FlashesPassed == 0) AudioManager.GetInstance().PlayOnce(NewGameMode.AudioAssets.GameModeTransition);
            base.Update(gameTime);

            FramesPassed++;

            if (FramesPassed >= FlashFreq)
            {
                FramesPassed = 0;
                FlashesPassed++;
                IsFlashing = !IsFlashing;

                if (!IsFlashing && GameModeManager.GetInstance().GameMode.Type == OldGameMode.Type)
                    GameModeManager.GetInstance().GameMode = NewGameMode;
                else if (!IsFlashing && GameModeManager.GetInstance().GameMode.Type == NewGameMode.Type)
                    GameModeManager.GetInstance().GameMode = OldGameMode;

                if (FlashesPassed >= NumFlashes)
                {
                    GameModeManager.GetInstance().GameMode = NewGameMode;
                    Game.CurrentState = PlayingState;
                    AudioManager.GetInstance().StopAudio();
                    AudioManager.GetInstance().PlayLooped(AudioMappings.GetInstance().MusicGame);
                }
            }
        }
    }
}
