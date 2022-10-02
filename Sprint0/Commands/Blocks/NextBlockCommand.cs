namespace Sprint0.Commands.Blocks
{
    public class NextBlockCommand : ICommand
    {
        private Game1 game;
        public NextBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentBlock = (game.currentBlock + 1) % game.blocks.Length;
        }
    }
}
