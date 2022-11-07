using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class WhiteBars : AbstractBlock
    {
        public WhiteBars(Vector2 position) : base(new WhiteBarsSprite(), position, false) { }
    }
}
