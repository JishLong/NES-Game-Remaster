using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Input.ClientInputHandlers;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class PauseState : AbstractGameState
    {
        private readonly IInputHandler ClientInputHandler;
        private readonly IGameState PrevGameState;

        // How quickly the "tips" text flashes on the screen; LOWER number = more flashing
        private static readonly int FlashingFreq = 15;
        // How big the elements appear on the screen; bigger number = bigger elements
        private static readonly float ElementScaling = 1.15f;
        // How big the text appears on the screen; bigger number = bigger elements
        private static readonly float TextScaling = 0.4f;

        // The positions of elements on the screen
        private Rectangle PanelPosition;
        private Vector2 FlashingTextPosition;
        private Vector2 UnpauseTextPosition;
        private Vector2 QuitTextPosition;

        // Logical variables to help check for certain conditions
        private bool IsShowing;
        private int FramesPassed;

        public PauseState(Game1 game, IGameState prevGameState) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetPauseStateMappings(Game, prevGameState)),
            };

            PrevGameState = prevGameState;

            SetElementPositions();

            IsShowing = true;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draw the game state that was just paused
            PrevGameState.Draw(sb);
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, 
                new Rectangle(0, 0, GameWindow.DefaultScreenWidth, GameWindow.DefaultScreenHeight),
                ImageMappings.GetInstance().ScreenCover, Color.Black * 0.5f, 0f, Vector2.Zero, SpriteEffects.None, 0.02f);

            // Draw the pause screen panel that is displayed on top of everything else
            sb.Draw(ImageMappings.GetInstance().GuiElementsSpriteSheet, PanelPosition, ImageMappings.GetInstance().Panel, 
                Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.01f);

            // Draw the text
            if (IsShowing) sb.DrawString(FontMappings.GetInstance().LargeFont, "- GAME PAUSED -", FlashingTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0f);
            sb.DrawString(FontMappings.GetInstance().SmallFont, "Press ESC to unpause", UnpauseTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0f);
            sb.DrawString(FontMappings.GetInstance().SmallFont, "Press Q to quit game", QuitTextPosition, Color.White, 0f, new Vector2(0, 0),
                GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0f);
        }

        public void SetElementPositions()
        {
            Rectangle PanelDims = ImageMappings.GetInstance().Panel;
            Vector2 FlashingTextSize = FontMappings.GetInstance().LargeFont.MeasureString("- GAME PAUSED -");
            Vector2 UnpauseTextSize = FontMappings.GetInstance().SmallFont.MeasureString("Press ESC to unpause");
            Vector2 QuitTextSize = FontMappings.GetInstance().SmallFont.MeasureString("Press Q to quit game");

            PanelPosition = new Rectangle(
                GameWindow.DefaultScreenWidth / 2 - (int)(PanelDims.Width * GameWindow.ResolutionScale * ElementScaling / 2),
                GameWindow.DefaultScreenHeight / 2 - (int)(PanelDims.Height * GameWindow.ResolutionScale * ElementScaling / 2),
                (int)(PanelDims.Width * GameWindow.ResolutionScale * ElementScaling),
                (int)(PanelDims.Height * GameWindow.ResolutionScale * ElementScaling));
            FlashingTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - FlashingTextSize.X * GameWindow.ResolutionScale * TextScaling / 2,
                PanelPosition.Y + FlashingTextSize.Y * GameWindow.ResolutionScale * TextScaling);
            UnpauseTextPosition = new Vector2(GameWindow.DefaultScreenWidth / 2 - UnpauseTextSize.X * GameWindow.ResolutionScale * TextScaling / 2,
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

            base.Update(gameTime);
        }
    }
}
