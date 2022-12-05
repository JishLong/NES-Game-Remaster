using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class BlueSand : AbstractBlock
    {
        public BlueSand(Vector2 position) : base(new BlueSandSprite(), position, false) { }
    }
}
