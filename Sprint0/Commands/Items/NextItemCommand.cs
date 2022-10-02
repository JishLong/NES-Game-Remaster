namespace Sprint0.Commands.Player
{
    public class NextItemCommand : ICommand
    {
        private Game1 game;

        public NextItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.currentItem = (game.currentItem + 1) % game.items.Length;
        }
    }
}

