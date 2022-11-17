namespace Sprint0.Commands.Inventory
{
    public class SelectLeftItemCommand : ICommand
    {
        private readonly Game1 Game;

        public SelectLeftItemCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.PlayerManager.GetDefaultPlayer().Inventory.SelectLeftItem();
        }
    }
}
