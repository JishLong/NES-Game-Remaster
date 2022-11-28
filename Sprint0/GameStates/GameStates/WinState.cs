using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Input.ClientInputHandlers;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class WinState : AbstractGameState
    {
        private readonly IInputHandler ClientInputHandler;

        private static readonly int HUDHeight = (int)(56 * GameWindow.ResolutionScale);
        // The number of frames is takes for the screen to fade to black; higher number = longer time
        private static readonly int FadeOutFrames = 200;
        // How quickly the win text flashes on the screen; LOWER number = more flashing
        private static readonly int TextFlashingFreq = 15;
        // How quickly the entire screen is flashing; LOWER number = more flashing
        private static readonly int ScreenFlashingFreq = 8;
        // How big the elements appear on the screen; bigger number = bigger elements
        private static readonly float ElementScaling = 1.15f;
        // How big the text appears on the screen; bigger number = bigger elements
        private static readonly float TextScaling = 0.4f;

        // The positions of elements on the screen
        private Rectangle PanelPosition;
        private Vector2 FlashingTextPosition;
        private Vector2 RestartTextPosition;
        private Vector2 QuitTextPosition;

        // Logical variables
        private bool IsShowing;
        private int FramesPassed;
        private bool IsFlashing;
        private float FadeAmount;

        public WinState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetWinStateMappings(Game, this)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            SetElementPositions();

            IsShowing = true;
            FramesPassed = 0;
            IsFlashing = true;
            FadeAmount = 0f;
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);
            Game.PlayerManager.Draw(sb);

            Camera.GetInstance().Move(Types.Direction.UP, HUDHeight);
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.DOWN, HUDHeight);

            if (IsFlashing && FramesPassed < FadeOutFrames)
            {
                sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight), null, Color.White * 0.1f,
                    0f, Vector2.Zero, SpriteEffects.None, 0.10f);
            }

            sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight), null, Color.Black * FadeAmount,
                0f, Vector2.Zero, SpriteEffects.None, 0.09f);
            if (FramesPassed > FadeOutFrames)
            {
                sb.Draw(Resources.PausePanel, PanelPosition, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.01f);

                // Draw the text
                if (IsShowing) sb.DrawString(Resources.LargeFont, "- YOU WIN :) -", FlashingTextPosition, Color.White, 0f, new Vector2(0, 0),
                    GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0f);
                sb.DrawString(Resources.SmallFont, "Press SPACE to play again", RestartTextPosition, Color.White, 0f, new Vector2(0, 0),
                    GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0f);
                sb.DrawString(Resources.SmallFont, "Press Q to quit game", QuitTextPosition, Color.White, 0f, new Vector2(0, 0),
                    GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0f);
            }
        }

        public void SetElementPositions()
        {
            Rectangle PanelDims = Resources.PausePanel.Bounds;
            Vector2 FlashingTextSize = Resources.LargeFont.MeasureString("- YOU WIN :) -");
            Vector2 UnpauseTextSize = Resources.SmallFont.MeasureString("Press SPACE to play again");
            Vector2 QuitTextSize = Resources.SmallFont.MeasureString("Press Q to quit game");

            PanelPosition = new Rectangle(
                GameWindow.DefaultScreenWidth / 2 - (int)(PanelDims.Width * GameWindow.ResolutionScale * ElementScaling / 2),
                GameWindow.DefaultScreenHeight / 2 - (int)(PanelDims.Height * GameWindow.ResolutionScale * ElementScaling / 2),
                (int)(PanelDims.Width * GameWindow.ResolutionScale * ElementScaling),
                (int)(PanelDims.Height * GameWindow.ResolutionScale * ElementScaling));
            FlashingTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - FlashingTextSize.X * GameWindow.ResolutionScale * TextScaling / 2,
                PanelPosition.Y + FlashingTextSize.Y * GameWindow.ResolutionScale * TextScaling);
            RestartTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - UnpauseTextSize.X * GameWindow.ResolutionScale * TextScaling / 2,
                PanelPosition.Y + PanelPosition.Height - UnpauseTextSize.Y * GameWindow.ResolutionScale * TextScaling * 6);
            QuitTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - QuitTextSize.X * GameWindow.ResolutionScale * TextScaling / 2,
                PanelPosition.Y + PanelPosition.Height - QuitTextSize.Y * GameWindow.ResolutionScale * TextScaling * 4);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            FramesPassed++;
            if (FramesPassed % ScreenFlashingFreq == 0) IsFlashing = !IsFlashing;
            if (FramesPassed % TextFlashingFreq == 0)
            {
                IsShowing = !IsShowing;
            }
            FadeAmount += 1f / FadeOutFrames;
        }
    }
}
