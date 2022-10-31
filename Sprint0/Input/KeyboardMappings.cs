using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.GameStates;
using Sprint0.Commands.Levels;
using Sprint0.Commands.Misc;
using Sprint0.Commands.Player;
using Sprint0.Controllers;
using Sprint0.Player;
using System.Collections.Generic;

namespace Sprint0.Input
{
    public class KeyboardMappings
    {
        private static KeyboardMappings Instance;

        public Dictionary<ActionMap, ICommand> PlayingStateMappings { get; private set; }
        public Dictionary<ActionMap, ICommand> PauseStateMappings { get; private set; }
        public Dictionary<ActionMap, ICommand> WinStateMappings { get; private set; }
        public Dictionary<ActionMap, ICommand> MainMenuStateMappings { get; private set; }
        public Dictionary<ActionMap, ICommand> LoseStateMappings { get; private set; }

        private KeyboardMappings() { }

        public static KeyboardMappings GetInstance() 
        {
            Instance ??= new KeyboardMappings();
            return Instance;
        }

        public void InitializeMappings(Game1 game, IPlayer player) 
        {
            PlayingStateMappings = new Dictionary<ActionMap, ICommand>() { 
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
                Keys.D, Keys.Right), new PlayerStopActionCommand(player) },

                // Player attack controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Z, Keys.N),
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
                    new PlayerTakeDamageCommand(player, player.FacingDirection, 0, game) },             

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
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new PauseGameCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
            PauseStateMappings = new Dictionary<ActionMap, ICommand>() { 
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new UnpauseGameCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
            WinStateMappings = new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
            MainMenuStateMappings = new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Space),
                    new StartGameCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
            LoseStateMappings = new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Space),
                    new RestartGameCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
        }
    }
}
