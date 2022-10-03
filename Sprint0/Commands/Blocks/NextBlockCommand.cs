using Sprint0.Blocks.Utils;

namespace Sprint0.Commands.Blocks
{
    public class NextBlockCommand : ICommand
    {
        private Game1 Game;

        public NextBlockCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentBlock = BlockFactory.GetInstance().GetNextBlock(BlockFactory.DefaultBlockPosition);
        }
    }
}
