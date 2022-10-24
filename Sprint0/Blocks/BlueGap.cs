using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks
{
    public class BlueGap : AbstractBlock
    {
        public BlueGap(Vector2 position) : base(position)
        {
            Sprite = new BlueGapSprite();
            Pushable = false;
            Walkable = false;
        }

        public override Rectangle GetHitbox()
        {
            Rectangle ActualHitbox = Sprite.GetDrawbox(Position);
            int ReducedWidth = ActualHitbox.Width / 2;
            int ReducedHeight = ActualHitbox.Height / 2;
            Vector2 hitboxPosition = Sprint0.Utils.CenterOnEdge(ActualHitbox, ReducedWidth, ReducedHeight, Types.Direction.UP);
            return new Rectangle((int)hitboxPosition.X, (int)hitboxPosition.Y, ReducedWidth, ReducedHeight);
        }
    }
}
