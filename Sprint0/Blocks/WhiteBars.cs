using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class WhiteBars : AbstractBlock
    {
        public WhiteBars(Vector2 position) : base(position)
        {
            Sprite = new WhiteBarsSprite();
        }
    }
}
