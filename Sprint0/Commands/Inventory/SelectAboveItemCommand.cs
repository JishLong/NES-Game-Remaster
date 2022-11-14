namespace Sprint0.Commands.Inventory
{
    public class SelectAboveItemCommand : ICommand
    {
        private readonly Game1 Game;

        public SelectAboveItemCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.Player.Inventory.SelectAboveItem();
        }
    }
}
