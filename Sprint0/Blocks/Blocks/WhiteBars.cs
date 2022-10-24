using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class WhiteBars : AbstractBlock
    {
        // Not sure whether white bars are a wall - set to true for now (so collision is on), but may change if new information is found
        public WhiteBars(Vector2 position) : base(new WhiteBarsSprite(), position, true) { }
    }
}
