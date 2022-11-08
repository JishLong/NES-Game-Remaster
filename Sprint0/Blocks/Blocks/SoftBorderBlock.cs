using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* This block is somewhat redundant (since the room border covers up the block anyways), but good to separate the concern of what it is
     * *Could easily just use a normal blue wall block instead of this (or any other block with [BlockIsWall] set to true)*
     */
    public class SoftBorderBlock : AbstractBlock
    {
        public SoftBorderBlock(Vector2 position) : base(new BorderBlockSprite(), position, true) { }
    }
}
