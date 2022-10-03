using Sprint0.Blocks.Utils;

namespace Sprint0.Commands.Blocks
{
    public class PrevBlockCommand : ICommand
{
        private Game1 Game;

        public PrevBlockCommand(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            Game.CurrentBlock = BlockFactory.GetInstance().GetPrevBlock(BlockFactory.DefaultBlockPosition);
        }
    }
}
