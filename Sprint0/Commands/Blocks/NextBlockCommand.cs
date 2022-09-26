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
            if (game.currentBlock < game.blocks.Length - 1)
            {
                game.currentBlock++;
            }
            else
            {
                game.currentBlock = 0;
            }
        }
    }
}
