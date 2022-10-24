using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class BlueStairs : AbstractBlock
    {
        public BlueStairs(Vector2 position) : base(new BlueStairsSprite(), position, false) { }
    }
}
