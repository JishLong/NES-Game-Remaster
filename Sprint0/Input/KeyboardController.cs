using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Player;
using Sprint0.Commands.Items;
using Sprint0.Commands.Enemies;
using Sprint0.Commands;
using Sprint0.Player.State;
using System.Collections.Generic;
using Sprint0.Commands.Blocks;
using Sprint0.Commands;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        // Can be utilized to handle more specific keyboard input
        private KeyboardState PrevState = Keyboard.GetState();

        // A list of every mapping of keyboard key(s) to actions
        private Dictionary<ActionMap, ICommand> ActionMaps;

        public KeyboardController(Game1 game, PlayerStateController playerStateController)
        {
            ActionMaps = new Dictionary<ActionMap, ICommand>
            {
                // Player movement controls
                { new ActionMap(ActionMap.KeyState.HELD, Keys.W, Keys.Up),
                    new PlayerUpInputCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.S, Keys.Down),
                    new PlayerDownInputCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.A, Keys.Left),
                    new PlayerLeftInputCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.D, Keys.Right),
                    new PlayerRightInputCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.W, Keys.Up),
                    new PlayerStopMovingCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.S, Keys.Down),
                    new PlayerStopMovingCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.A, Keys.Left),
                    new PlayerStopMovingCommand(playerStateController) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.D, Keys.Right),
                    new PlayerStopMovingCommand(playerStateController) },

                // Player attack controls
                { new ActionMap(ActionMap.KeyState.HELD, Keys.Z, Keys.N),
                    new PlayerSwordAttackCommand(playerStateController) },

                // Player damage control
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.E),
                    new PlayerTakeDamageCommand(playerStateController) },

                // Item switching controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.U),
                    new PrevItemCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.I),
                    new NextItemCommand(game) },

                //// Enemy switching controls
                //{ new KeyMap(KeyMap.KeyState.PRESSED, Keys.O),
                //    new PrevEnemyCommand(game) },
                //{ new KeyMap(KeyMap.KeyState.PRESSED, Keys.P),
                //    new NextEnemyCommand(game) },
                
                // Enemy switching controls
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.O),
                    new PrevCharacterCommand(game) },
                
                { new KeyMap(KeyMap.KeyState.PRESSED, Keys.P),
                    new NextCharacterCommand(game) },

                // Block switching controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.T),
                    new PrevBlockCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Y),
                    new NextBlockCommand(game) },

                // Misc. controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) }
            };
        }

        public void Update()
        {
            KeyboardState currentState = Keyboard.GetState();

            foreach (var mapping in ActionMaps)
            {
                if (mapping.Key.IsActivated(PrevState, currentState))
                {
                    mapping.Value.Execute();
                }
            }

            PrevState = currentState;
        }
    }
}
