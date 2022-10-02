using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueGap : AbstractBlock
    {
        public BlueGap(Vector2 pos) : base(pos)
        {
            sprite = new BlueGapSprite();
        }
    }
}
