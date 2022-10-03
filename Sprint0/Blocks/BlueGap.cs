using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueGap : AbstractBlock
    {
        public BlueGap(Vector2 position) : base(position)
        {
            Sprite = new BlueGapSprite();
        }
    }
}
