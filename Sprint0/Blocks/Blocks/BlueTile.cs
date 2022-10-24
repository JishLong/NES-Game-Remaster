using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class BlueTile : AbstractBlock
    {
        public BlueTile(Vector2 position) : base(new BlueTileSprite(), position, false) { }
    }
}
