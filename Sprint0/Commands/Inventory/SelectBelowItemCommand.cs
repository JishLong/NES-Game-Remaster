namespace Sprint0.Commands.Inventory
{
    public class SelectBelowItemCommand : ICommand
    {
        private readonly Game1 Game;

        public SelectBelowItemCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.Player.Inventory.SelectBelowItem();
        }
    }
}
