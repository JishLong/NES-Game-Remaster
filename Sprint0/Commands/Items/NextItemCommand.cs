using Sprint0.Items.Utils;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Items
{
    public class NextItemCommand : ICommand
    {
        private Game1 Game;
        private Vector2 DefaultItemPosition;

        public NextItemCommand(Game1 game)
        {
            Game = game;
            DefaultItemPosition = new Vector2(300, 300);
        }

        public void Execute()
        {
            Game.CurrentItem = ItemFactory.GetInstance().GetNextItem(DefaultItemPosition);
        }
    }
}

