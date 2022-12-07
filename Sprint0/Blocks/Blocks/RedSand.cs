using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class RedSand: AbstractBlock
    {
        public RedSand(Vector2 position) : base(new RedSandSprite(), position, false) { }
    }
}
