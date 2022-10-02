using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class WhiteBars : AbstractBlock
    {
        public WhiteBars(Vector2 pos) : base(pos)
        {
            sprite = new WhiteBarsSprite();
        }
    }
}
