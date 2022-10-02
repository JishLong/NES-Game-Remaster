using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueStairs : AbstractBlock
    {
        public BlueStairs(Vector2 pos) : base(pos)
        {
            sprite = new BlueStairsSprite();
        }
    }
}
