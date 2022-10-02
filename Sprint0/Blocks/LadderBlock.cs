using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class LadderBlock : AbstractBlock
    {
        public LadderBlock(Vector2 pos) : base(pos)
        {
            sprite = new LadderBlockSprite();
        }
    }
}

