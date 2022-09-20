using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Player;
using Sprint0.Player.State;
using System.Collections.Generic;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        private Game1 game;
        private Dictionary<Keys, ICommand> keyMap;
        private PlayerStateController playerStateController;

        public KeyboardController(Game1 game, PlayerStateController playerStateController) 
        {
            this.game = game;
            this.playerStateController = playerStateController;

            keyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.Q, new QuitCommand(game) },
                { Keys.D1, new StillSpriteCommand(game) },
                { Keys.D2, new AnimatedSpriteCommand(game) },
                { Keys.D3, new MovingSpriteCommand(game) },
                { Keys.D4, new MovingAnimatedSpriteCommand(game) },

                // Link movement controls
                { Keys.W, new PlayerUpInputCommand(playerStateController) },
                { Keys.S, new PlayerDownInputCommand(playerStateController) },
                { Keys.A, new PlayerLeftInputCommand(playerStateController) },
                { Keys.D, new PlayerRightInputCommand(playerStateController) },
                { Keys.Up, new PlayerUpInputCommand(playerStateController) },
                { Keys.Down, new PlayerDownInputCommand(playerStateController) },
                { Keys.Left, new PlayerLeftInputCommand(playerStateController) },
                { Keys.Right, new PlayerRightInputCommand(playerStateController) }
            };
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
