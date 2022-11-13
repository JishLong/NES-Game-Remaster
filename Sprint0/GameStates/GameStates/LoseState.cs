﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class LoseState : AbstractGameState
    {
        private readonly Vector2 flashingTextPosition;
        private readonly Vector2 unpauseTextPosition;
        private readonly Vector2 quitTextPosition;

        private readonly int FlashingFrames;
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

            Vector2 unpauseTextSize = Resources.MediumFont.MeasureString("Press SPACE to restart");
            Vector2 quitTextSize = Resources.MediumFont.MeasureString("Press Q to quit game");
            Vector2 flashingTextSize = Resources.LargeFont.MeasureString("- YOU DIED :( -");
            quitTextPosition = new Vector2(Utils.GameWidth / 2 - quitTextSize.X / 2, Utils.GameHeight * 2 / 3 - quitTextSize.Y / 2);
            unpauseTextPosition = new Vector2(Utils.GameWidth / 2 - unpauseTextSize.X / 2, quitTextPosition.Y - unpauseTextSize.Y * 3 / 2);
            flashingTextPosition = new Vector2(Utils.GameWidth / 2 - flashingTextSize.X / 2, unpauseTextPosition.Y - flashingTextSize.Y * 3);

            FlashingFrames = 30;
            IsShowing = true;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
            Game.Player.HUD.Draw(sb);
            Camera.GetInstance().Reset();

            Rectangle PanelDims = Resources.PausePanel.Bounds;
            Rectangle PanelLocation = new Rectangle(
                Utils.GameWidth / 2 - (int)(PanelDims.Width * Utils.GameScale / 2),
                Utils.GameHeight / 2 - (int)(PanelDims.Height * Utils.GameScale / 2),
                (int)(PanelDims.Width * Utils.GameScale),
                (int)(PanelDims.Height * Utils.GameScale));
            sb.Draw(Resources.PausePanel, PanelLocation, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.01f) ;

            sb.DrawString(Resources.MediumFont, "Press SPACE to restart", unpauseTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            sb.DrawString(Resources.MediumFont, "Press Q to quit game", quitTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

            if (IsShowing) sb.DrawString(Resources.LargeFont, "- YOU DIED :( -", flashingTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            FramesPassed++;
            if (FramesPassed % FlashingFrames == 0)
            {
                IsShowing = !IsShowing;
            }

            base.Update(gameTime);
        }
    }
}
