using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* This block is somewhat redundant (since the room border covers up the block anyways), but good to separate the concern of what it is
     * *Could easily just use a normal blue wall block instead of this (or any other block with [BlockIsWall] set to true)*
     */
    public class BorderBlock : AbstractBlock
    {
        public BorderBlock(Vector2 position) : base(new BorderBlockSprite(), position, true) { }
    }
}
