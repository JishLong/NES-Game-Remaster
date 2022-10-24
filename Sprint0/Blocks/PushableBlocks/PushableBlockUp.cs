using Microsoft.Xna.Framework;

namespace Sprint0.Blocks.PushableBlocks
{
    // Currently the only concrete pushable block class - no other ones have been needed!
    public class PushableBlockUp : AbstractPushableBlock
    {
        public PushableBlockUp(Vector2 position) : base(position, Types.Direction.UP) { }
    }
}
