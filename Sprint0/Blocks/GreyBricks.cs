using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class GreyBricks : AbstractBlock
    {
        public GreyBricks(Vector2 position) : base(position)
        {
            Sprite = new GreyBricksSprite();
        }
    }
}
