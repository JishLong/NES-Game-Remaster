using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Character;
using Sprint0.Commands.GameStates;
using Sprint0.Commands.Misc;
using Sprint0.Commands.Player;
using Sprint0.Controllers;
using Sprint0.GameStates;
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

        public Dictionary<ActionMap, ICommand> GetPlayingStateMappings(Game1 game, IPlayer player, IGameState currentGameState) 
        {
            return new Dictionary<ActionMap, ICommand>() { 
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

                // Misc. controls               
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new PauseGameCommand(game, currentGameState) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.I),
                    new MoveCameraCommand(Types.Direction.LEFT, 5) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.P),
                    new MoveCameraCommand(Types.Direction.RIGHT, 5) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.O),
                    new MoveCameraCommand(Types.Direction.UP, 5) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.L),
                    new MoveCameraCommand(Types.Direction.DOWN, 5) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.E),
                    new ToggleInventoryCommand(game) },
            };
        }

        public Dictionary<ActionMap, ICommand> GetWinStateMappings(Game1 game, IGameState currentGameState) 
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Space),
                    new RestartGameCommand(game) },
            };
        }

        public Dictionary<ActionMap, ICommand> GetRoomTransitionStateMappings(Game1 game, IGameState currentGameState) 
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new PauseGameCommand(game, currentGameState) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
        }

        public Dictionary<ActionMap, ICommand> GetMainMenuStateMappings(Game1 game)
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Space),
                    new StartGameCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
        }

        public Dictionary<ActionMap, ICommand> GetLoseStateMappings(Game1 game) 
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Space),
                    new RestartGameCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
        }

        public Dictionary<ActionMap, ICommand> GetPauseStateMappings(Game1 game, IGameState prevGameState) 
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new UnpauseGameCommand(game, prevGameState) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Q),
                    new QuitCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
        }

        public Dictionary<ActionMap, ICommand> GetInventoryTransitionStateMappings(Game1 game, IGameState currentGameState) 
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new PauseGameCommand(game, currentGameState) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
            };
        }

        public Dictionary<ActionMap, ICommand> GetInventoryStateMappings(Game1 game, IGameState currentGameState) 
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.E),
                    new ToggleInventoryCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new PauseGameCommand(game, currentGameState) },
            };
        }
    }
}
