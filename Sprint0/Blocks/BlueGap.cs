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
            return new Rectangle(ActualHitbox.Center.X - ReducedWidth / 2, ActualHitbox.Y, ReducedWidth, ReducedHeight);
        }
    }
}
