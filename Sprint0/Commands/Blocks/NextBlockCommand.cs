using Sprint0.Blocks.Utils;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Blocks
{
    public class NextBlockCommand : ICommand
    {
        private Game1 Game;
        private Vector2 DefaultBlockPosition;

        public NextBlockCommand(Game1 game)
        {
            Game = game;
            DefaultBlockPosition = new Vector2(200, 200);
        }

        public void Execute()
        {
            Game.CurrentBlock = BlockFactory.GetInstance().GetNextBlock(DefaultBlockPosition);
        }
    }
}
