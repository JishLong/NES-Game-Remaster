using Sprint0.Items.Utils;

namespace Sprint0.Commands.Items
{
    public class NextItemCommand : ICommand
    {
        private Game1 Game;

        public NextItemCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentItem = ItemFactory.GetInstance().GetNextItem(ItemFactory.DefaultItemPosition);
        }
    }
}
