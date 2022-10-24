using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class BlueStatueLeft : AbstractBlock
    {
        public BlueStatueLeft(Vector2 position) : base(new BlueStatueLeftSprite(), position, true) { }
    }
}
