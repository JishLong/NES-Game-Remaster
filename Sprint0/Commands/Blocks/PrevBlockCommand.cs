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
            game.currentBlock = (game.currentBlock - 1 + game.blocks.Length) % game.blocks.Length;
        }
    }
}