using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class Sand: AbstractBlock
    {
        public Sand(Vector2 position) : base(new SandSprite(), position, false) { }
    }
}
