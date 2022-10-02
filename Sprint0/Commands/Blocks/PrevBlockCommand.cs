using Sprint0.Blocks.Utils;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Blocks
{
    public class PrevBlockCommand : ICommand
{
        private Game1 Game;
        private Vector2 DefaultBlockPosition;

        public PrevBlockCommand(Game1 game)
        {
            Game = game;
            DefaultBlockPosition = new Vector2(200, 200);
        }
        public void Execute()
        {
            Game.CurrentBlock = BlockFactory.GetInstance().GetPrevBlock(DefaultBlockPosition);
    }
    }
}