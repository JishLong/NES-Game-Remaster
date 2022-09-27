namespace Sprint0.Commands.Blocks
{
    public class PrevBlockCommand : ICommand
    {
        private Game1 game;
        public PrevBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.currentBlock > 0)
            {
                game.currentBlock--;
            }
            else
            {
                game.currentBlock = game.blocks.Length - 1;
            }
        }
    }
}