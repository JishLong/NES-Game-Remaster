using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Player
{
    public class PrevItemCommand : ICommand
    {
        private Game1 game;

        public PrevItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.currentItem = (game.currentItem - 1 + game.items.Length) % game.items.Length;
        }
    }
}

