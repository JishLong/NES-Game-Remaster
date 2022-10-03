using Sprint0.Items.Utils;

namespace Sprint0.Commands.Items
{
    public class PrevItemCommand : ICommand
    {
        private Game1 Game;

        public PrevItemCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentItem = ItemFactory.GetInstance().GetPrevItem(ItemFactory.DefaultItemPosition);
        }
    }
}
