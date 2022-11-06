using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class WinState : AbstractGameState
    { 
        public WinState()
        {
            Controllers ??= new List<IController>()
            {
                new KeyboardController(KeyboardMappings.GetInstance().WinStateMappings),
            };
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);
            sb.DrawString(Resources.MediumFont, "Winner winner chicken dinner!!", new Vector2(30, 100), Color.Black, 0f, new Vector2(0,0), 1f, SpriteEffects.None, 0f);
        }
    }
}
