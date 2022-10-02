using Sprint0.Items.Utils;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Items
{
    public class PrevItemCommand : ICommand
    {
        private Game1 Game;
        private Vector2 DefaultItemPosition;

        public PrevItemCommand(Game1 game)
        {
            Game = game;
            DefaultItemPosition = new Vector2(300, 300);
        }

        public void Execute()
        {
            Game.CurrentItem = ItemFactory.GetInstance().GetPrevItem(DefaultItemPosition);
        }
    }
}

