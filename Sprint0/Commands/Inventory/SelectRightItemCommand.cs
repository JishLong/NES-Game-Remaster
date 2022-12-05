namespace Sprint0.Commands.Inventory
{
    public class SelectRightItemCommand : ICommand
    {
        private readonly Game1 Game;

        public SelectRightItemCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.PlayerManager.GetDefaultPlayer().Inventory.SelectRightItem();
        }
    }
}
