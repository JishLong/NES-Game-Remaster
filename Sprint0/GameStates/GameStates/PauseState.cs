using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using Sprint0.Levels;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class PauseState : AbstractGameState
    {
        private static List<IController> Controllers;

        public PauseState()
        {
            Controllers ??= new List<IController>()
            {
                new KeyboardController(KeyboardMappings.GetInstance().PauseStateMappings),
                new MouseController(MouseMappings.GetInstance().PauseStateMappings),
            };
        }

        public override void Draw(SpriteBatch sb)
        {
            LevelManager.Draw(sb);
            Player.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var controller in Controllers)
            {
                controller.Update();
            }
        }
    }
}
