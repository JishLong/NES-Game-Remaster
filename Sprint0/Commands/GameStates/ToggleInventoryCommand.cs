using Sprint0.GameStates;
using Sprint0.GameStates.GameStates;

namespace Sprint0.Commands.GameStates
{
    public class ToggleInventoryCommand : ICommand
    {
        private readonly Game1 Game;

        public ToggleInventoryCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            if (Game.CurrentState is InventoryState) Game.CurrentState = new InventoryTransitionState(Game, Types.Direction.DOWN);
            else if (Game.CurrentState is PlayingState) Game.CurrentState = new InventoryTransitionState(Game, Types.Direction.UP);
        }
    }
}
