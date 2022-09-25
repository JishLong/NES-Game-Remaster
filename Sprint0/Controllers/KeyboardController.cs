using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Player;
using Sprint0.Player.State;
using System.Collections.Generic;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        private Game1 game;
        private Dictionary<Keys, ICommand> heldKeyMap;
        private Dictionary<Keys, ICommand> clickedKeyMap;
        private Dictionary<Keys, ICommand> releasedKeyMap;
        private PlayerStateController playerStateController;

        // Used so that only the "pulse" of the mouse is registered rather than just looking for the button held down
        private KeyboardState prevState;

        public KeyboardController(Game1 game, PlayerStateController playerStateController) 
        {
            this.game = game;
            this.playerStateController = playerStateController;

            heldKeyMap = new Dictionary<Keys, ICommand>
            {   
                // Link movement controls
                { Keys.W, new PlayerUpInputCommand(playerStateController) },
                { Keys.S, new PlayerDownInputCommand(playerStateController) },
                { Keys.A, new PlayerLeftInputCommand(playerStateController) },
                { Keys.D, new PlayerRightInputCommand(playerStateController) },
                { Keys.Up, new PlayerUpInputCommand(playerStateController) },
                { Keys.Down, new PlayerDownInputCommand(playerStateController) },
                { Keys.Left, new PlayerLeftInputCommand(playerStateController) },
                { Keys.Right, new PlayerRightInputCommand(playerStateController) },
                { Keys.Z, new PlayerSwordAttackCommand(playerStateController) },
                { Keys.N, new PlayerSwordAttackCommand(playerStateController) }
            };

            clickedKeyMap = new Dictionary<Keys, ICommand>
            {
                // Item switching controls
                { Keys.U, new PrevItemCommand(game) },
                { Keys.I, new NextItemCommand(game) }
            };

            releasedKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.W, new PlayerStopMovingCommand(playerStateController) },
                { Keys.S, new PlayerStopMovingCommand(playerStateController) },
                { Keys.A, new PlayerStopMovingCommand(playerStateController) },
                { Keys.D, new PlayerStopMovingCommand(playerStateController) },
                { Keys.Up, new PlayerStopMovingCommand(playerStateController) },
                { Keys.Down, new PlayerStopMovingCommand(playerStateController) },
                { Keys.Left, new PlayerStopMovingCommand(playerStateController) },
                { Keys.Right, new PlayerStopMovingCommand(playerStateController) }
            };

            prevState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState CurrentState = Keyboard.GetState();

            foreach (var key in heldKeyMap.Keys)
            {
                if (CurrentState.IsKeyDown(key))
                {
                    heldKeyMap[key].Execute();
                }
            }

            foreach (var key in clickedKeyMap.Keys)
            {
                if (CurrentState.IsKeyDown(key) && prevState.IsKeyUp(key))
                {
                    clickedKeyMap[key].Execute();
                }
            }

            foreach (var key in releasedKeyMap.Keys)
            {
                if (prevState.IsKeyDown(key) && CurrentState.IsKeyUp(key))
                {
                    releasedKeyMap[key].Execute();
                }
            }

            prevState = CurrentState;
        }
    }
}
