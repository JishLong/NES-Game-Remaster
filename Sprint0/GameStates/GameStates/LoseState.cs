using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Input.ClientInputHandlers;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class LoseState : AbstractGameState
    {
        private readonly IInputHandler ClientInputHandler;

        // The number of frames until the panel appears
        private static readonly int PanelDelayFrames = 160;
        // How quickly the win text flashes on the screen; LOWER number = more flashing
        private static readonly int FlashingFreq = 15;
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

        public LoseState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetLoseStateMappings(Game)),
                new MouseController(MouseMappings.GetInstance().NoMappings)
            };

            SetElementPositions();

            IsShowing = true;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);

            Camera.GetInstance().Move(Types.Direction.UP, (int)(56 * GameWindow.ResolutionScale));
            Game.PlayerManager.GetDefaultPlayer().HUD.Draw(sb);
            Camera.GetInstance().Reset();

            sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight), null,
                Color.Red * 0.5f, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            Game.PlayerManager.Draw(sb);

            if (FramesPassed > PanelDelayFrames)
            {
                sb.Draw(Resources.PausePanel, PanelPosition, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.01f);

                // Draw the text
                if (IsShowing) sb.DrawString(Resources.LargeFont, "- YOU DIED :( -", FlashingTextPosition, Color.White, 0f, new Vector2(0, 0),
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
            Vector2 FlashingTextSize = Resources.LargeFont.MeasureString("- YOU DIED :( -");
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
            FramesPassed++;
            if (FramesPassed % FlashingFreq == 0)
            {
                IsShowing = !IsShowing;
            }

            Game.PlayerManager.Update();

            base.Update(gameTime);
        }
    }
}
