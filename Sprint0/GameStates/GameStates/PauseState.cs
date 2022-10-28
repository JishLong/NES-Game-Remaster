using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class PauseState : AbstractGameState
    {
        public PauseState()
        {
            Controllers ??= new List<IController>()
            {
                new KeyboardController(KeyboardMappings.GetInstance().PauseStateMappings)
            };
        }

        public override void Draw(SpriteBatch sb)
        {
            Game.LevelManager.Draw(sb);
            Game.Player.Draw(sb);
        }
    }
}
