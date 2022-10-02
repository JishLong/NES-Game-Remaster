using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class GreyBricks : AbstractBlock
    {
        public GreyBricks(Vector2 pos) : base(pos)
        {
            sprite = new GreyBricksSprite();
        }
    }
}
