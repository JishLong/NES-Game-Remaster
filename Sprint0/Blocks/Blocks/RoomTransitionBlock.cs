using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class RoomTransitionBlock : AbstractBlock
    {
        public RoomTransitionBlock(Vector2 position) : base(new BorderBlockSprite(), position, true) { }
    }
}
