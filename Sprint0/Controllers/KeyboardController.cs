using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        private Game1 game;
        private Dictionary<Keys, ICommand> keyMap;

        public KeyboardController(Game1 game) 
        {
            this.game = game;

            keyMap = new Dictionary<Keys, ICommand>();
            keyMap.Add(Keys.D0, new QuitCommand(game));
            keyMap.Add(Keys.D1, new StillSpriteCommand(game));
            keyMap.Add(Keys.D2, new AnimatedSpriteCommand(game));
            keyMap.Add(Keys.D3, new MovingSpriteCommand(game));
            keyMap.Add(Keys.D4, new MovingAnimatedSpriteCommand(game));
        }

        public void Update()
        {
            foreach (var key in keyMap.Keys)
            {
                if (Keyboard.GetState().IsKeyDown(key))
                {
                    keyMap[key].Execute();
                }
            }
        }
    }
}
