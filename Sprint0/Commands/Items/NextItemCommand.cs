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
            if (game.currentItem < game.items.Length - 1)
            {
                game.currentItem++;
            }
            else {
                game.currentItem = 0;
            }
        }
    }
}

