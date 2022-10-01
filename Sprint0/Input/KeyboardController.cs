using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Player;
using Sprint0.Commands.Enemies;
using Sprint0.Player.State;
using System.Collections.Generic;
using Sprint0.Commands.Blocks;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        // Comparing these two keyboard states can be utilized to handle more specific keyboard input
        private KeyboardState prevState = Keyboard.GetState();
        private KeyboardState currentState;

        // A list of every keyboard control mapping
        private Dictionary<KeyMap, ICommand> keyMap;

        public KeyboardController(Game1 game, PlayerStateController playerStateController)
        {
            keyMap = new Dictionary<KeyMap, ICommand>
            {
                // Player movement controls
                { new KeyMap(KeyMap.KeyState.HELD, Keys.W, Keys.Up),
                    new PlayerUpInputCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.HELD, Keys.S, Keys.Down),
                    new PlayerDownInputCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.HELD, Keys.A, Keys.Left),
                    new PlayerLeftInputCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.HELD, Keys.D, Keys.Right),
                    new PlayerRightInputCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.RELEASED, Keys.W, Keys.Up),
                    new PlayerStopMovingCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.RELEASED, Keys.S, Keys.Down),
                    new PlayerStopMovingCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.RELEASED, Keys.A, Keys.Left),
                    new PlayerStopMovingCommand(playerStateController) },
                { new KeyMap(KeyMap.KeyState.RELEASED, Keys.D, Keys.Right),
                    new PlayerStopMovingCommand(playerStateController) },

                // Player attack controls
                { new KeyMap(KeyMap.KeyState.HELD, Keys.Z, Keys.N),
                    new PlayerSwordAttackCommand(playerStateController) },

                // Player damage control
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.E),
                    new PlayerTakeDamageCommand(playerStateController) },

                // Item switching controls
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.U),
                    new PrevItemCommand(game) },
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.I),
                    new NextItemCommand(game) },

                // Enemy switching controls
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.O),
                    new PrevEnemyCommand(game) },
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.P),
                    new NextEnemyCommand(game) },

                // Block switching controls
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.T),
                    new PrevBlockCommand(game) },
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.Y),
                    new NextBlockCommand(game) }
            };
        }

        public void Update()
        {
            currentState = Keyboard.GetState();

            foreach (var mapping in keyMap)
            {
                if (mapping.Key.IsActivated(prevState, currentState))
                {
                    mapping.Value.Execute();
                }
            }

            prevState = currentState;
        }
    }
}
