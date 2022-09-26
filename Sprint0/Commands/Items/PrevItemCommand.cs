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
            if (game.currentItem > 0)
            {
                game.currentItem--;
            }
            else
            {
                game.currentItem = game.items.Length - 1;
            }
        }
    }
}

