using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class WinState : AbstractGameState
    {
        private readonly Vector2 flashingTextPosition;
        private readonly Vector2 unpauseTextPosition;
        private readonly Vector2 quitTextPosition;

        private readonly int FlashingFrames;
        private bool IsShowing;

        private int FramesPassed;
        private bool IsFlashing;
        private float FadeAmount;
        private int FadeOutFrames;

        public WinState()
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetWinStateMappings(Game, this)),
            };

            Vector2 unpauseTextSize = Resources.SmallFont.MeasureString("Press SPACE to play again");
            Vector2 quitTextSize = Resources.MediumFont.MeasureString("Press Q to quit game");
            Vector2 flashingTextSize = Resources.LargeFont.MeasureString("- YOU WIN! :) -");
            quitTextPosition = new Vector2(Utils.GameWidth / 2 - quitTextSize.X / 2, Utils.GameHeight * 2 / 3 - quitTextSize.Y / 2);
            unpauseTextPosition = new Vector2(Utils.GameWidth / 2 - unpauseTextSize.X / 2, quitTextPosition.Y - unpauseTextSize.Y * 3 / 2);
            flashingTextPosition = new Vector2(Utils.GameWidth / 2 - flashingTextSize.X / 2, unpauseTextPosition.Y - flashingTextSize.Y * 3);

            FlashingFrames = 30;
            IsShowing = true;

            FramesPassed = 0;
            IsFlashing = true;
            FadeAmount = 0f;
            FadeOutFrames = 200;
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);          
            if (IsFlashing && FramesPassed < FadeOutFrames) 
            {
                sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, Utils.GameWidth, Utils.GameHeight), null, Color.White * 0.3f, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            }
            sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, Utils.GameWidth, Utils.GameHeight), null, Color.Black * FadeAmount, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            if (FramesPassed > FadeOutFrames) 
            {
                Rectangle PanelDims = Resources.PausePanel.Bounds;
                Rectangle PanelLocation = new Rectangle(
                    Utils.GameWidth / 2 - (int)(PanelDims.Width * Utils.GameScale / 2),
                    Utils.GameHeight / 2 - (int)(PanelDims.Height * Utils.GameScale / 2),
                    (int)(PanelDims.Width * Utils.GameScale),
                    (int)(PanelDims.Height * Utils.GameScale));
                sb.Draw(Resources.PausePanel, PanelLocation, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.01f);

                sb.DrawString(Resources.SmallFont, "Press SPACE to play again", unpauseTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
                sb.DrawString(Resources.MediumFont, "Press Q to quit game", quitTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

                if (IsShowing) sb.DrawString(Resources.LargeFont, "- YOU WIN! :) -", flashingTextPosition, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);

            FramesPassed++;
            if (FramesPassed % 4 == 0) IsFlashing = !IsFlashing;
            if (FramesPassed % FlashingFrames == 0)
            {
                IsShowing = !IsShowing;
            }
            FadeAmount += 1f / FadeOutFrames;
        }
    }
}
