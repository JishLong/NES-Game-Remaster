using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class BlueWall : AbstractBlock
    {
        public BlueWall(Vector2 position) : base(new BlueWallSprite(), position, true) { }
    }
}
