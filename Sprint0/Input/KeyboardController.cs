using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Player;
using Sprint0.Commands;
using Sprint0.Player;
using System.Collections.Generic;
using Sprint0.Commands.Levels;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        // Can be utilized to handle more specific keyboard input
        private KeyboardState PrevState = Keyboard.GetState();

        // A list of every mapping of keyboard key(s) to actions
        private Dictionary<ActionMap, ICommand> ActionMaps;

        public KeyboardController(Game1 game, IPlayer player)
        {
            ActionMaps = new Dictionary<ActionMap, ICommand>
            {
                // Player movement controls
                { new ActionMap(ActionMap.KeyState.HELD, Keys.W, Keys.Up),
                    new PlayerMoveUpCommand(player) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.S, Keys.Down),
                    new PlayerMoveDownCommand(player) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.A, Keys.Left),
                    new PlayerMoveLeftCommand(player) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.D, Keys.Right),
                    new PlayerMoveRightCommand(player) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.W, Keys.Up, Keys.S, Keys.Down, Keys.A, Keys.Left,
                Keys.D, Keys.Right, Keys.Z, Keys.N, Keys.D1),
                    new PlayerStopActionCommand(player) },

                // Player attack controls
                { new ActionMap(ActionMap.KeyState.HELD, Keys.Z, Keys.N),
                    new PlayerSwordAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.D1),
                    new PlayerArrowAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.D2),
                    new PlayerBlueArrowAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.D3),
                    new PlayerBoomerangAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.D4),
                    new PlayerFlameAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.D5),
                    new PlayerBombAttackCommand(player) },

                // Player damage control
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.E),
                    new PlayerTakeDamageCommand(player) },             

                // Room switching controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.NumPad4, Keys.D7),
                    new LeftRoomTransitionCommand(game)},
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.NumPad6, Keys.D8),
                    new RightRoomTransitionCommand(game)},
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.NumPad8, Keys.D0),
                    new UpRoomTransitionCommand(game)},
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.NumPad2, Keys.D9),
                    new DownRoomTransitionCommand(game)},

                // Misc. controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.R),
                    new ResetCommand(game, player) }
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
