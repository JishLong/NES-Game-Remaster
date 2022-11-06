using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class WinState : AbstractGameState
    {
        private int FramesPassed;
        private bool IsFlashing;

        public WinState()
        {
            Controllers ??= new List<IController>()
            {
                new KeyboardController(KeyboardMappings.GetInstance().WinStateMappings),
            };

            FramesPassed = 0;
            IsFlashing = true;
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);          
            if (IsFlashing) 
            {
                sb.Draw(Resources.ScreenCover, new Rectangle(0, 0, Utils.GameWidth, Utils.GameHeight), Color.White);
            }
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);

            FramesPassed++;
            if (FramesPassed % 4 == 0) IsFlashing = !IsFlashing;
        }
    }
}
