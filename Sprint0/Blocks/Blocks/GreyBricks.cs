using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class GreyBricks : AbstractBlock
    {
        public GreyBricks(Vector2 position) : base(new GreyBricksSprite(), position, true) { }
    }
}
