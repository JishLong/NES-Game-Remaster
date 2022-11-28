using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.GameStates;
using Sprint0.Commands.Inventory;
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

        private KeyboardMappings() { }

        public static KeyboardMappings GetInstance() 
        {
            Instance ??= new KeyboardMappings();
            return Instance;
        }

        public Dictionary<ActionMap, ICommand> GetPlayingStateMappings(Game1 game, IPlayer player, IGameState currentGameState) 
        {
            return new Dictionary<ActionMap, ICommand>()
            { 
                // Player movement controls
                { new ActionMap(ActionMap.KeyState.HELD, Keys.W, Keys.Up),
                    new PlayerMoveCommand(player, Types.Direction.UP) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.S, Keys.Down),
                    new PlayerMoveCommand(player, Types.Direction.DOWN) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.A, Keys.Left),
                    new PlayerMoveCommand(player, Types.Direction.LEFT) },
                { new ActionMap(ActionMap.KeyState.HELD, Keys.D, Keys.Right),
                    new PlayerMoveCommand(player, Types.Direction.RIGHT) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.W, Keys.Up, Keys.S, Keys.Down, Keys.A, Keys.Left,
                Keys.D, Keys.Right), new PlayerStopActionCommand(player) },

                // Player attack controls
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Z, Keys.N),
                    new PlayerSwordAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.C),
                    new PlayerArrowAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.C),
                    new PlayerBlueArrowAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.C),
                    new PlayerBoomerangAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.C),
                    new PlayerFlameAttackCommand(player) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.C),
                    new PlayerBombAttackCommand(player) },          

                // Misc. controls               
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new PauseGameCommand(game, currentGameState) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.M),
                    new ToggleAudioCommand() },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.E),
                    new ToggleInventoryCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Enter),
                    new ToggleCommandLineCommand(game) },
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
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.W),
                    new SelectAboveItemCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.S),
                    new SelectBelowItemCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.A),
                    new SelectLeftItemCommand(game) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.D),
                    new SelectRightItemCommand(game) },
            };
        }

        public Dictionary<ActionMap, ICommand> GetCommandLineStateMappings(Game1 game, IGameState currentGameState)
        {
            return new Dictionary<ActionMap, ICommand>() {
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Enter, Keys.Space, Keys.Back, Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G,
                Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V,
                Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0),
                    new CommandLineTypeKeyCommand(currentGameState) },
                { new ActionMap(ActionMap.KeyState.RELEASED, Keys.Enter, Keys.Space, Keys.Back, Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G,
                Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V,
                Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0),
                    new CommandLineReleaseKeyCommand(currentGameState) },
                { new ActionMap(ActionMap.KeyState.PRESSED, Keys.Escape),
                    new ToggleCommandLineCommand(game) },
            };
        }
    }
}
