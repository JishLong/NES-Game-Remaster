using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class Water : AbstractBlock
    {
        public Water(Vector2 position) : base(new WaterSprite(), position, true) { }

        // For the water, a smaller hitbox looks better so the player is able to walk on the edge
        public override Rectangle GetHitbox()
        {
            // Get the original hitbox
            Rectangle OriginalHitbox = Sprite.GetHitbox(Position);

            // Slightly reduce the dimensions of the hitbox
            int ReducedWidth = OriginalHitbox.Width / 2;
            int ReducedHeight = OriginalHitbox.Height / 2;

            // We'll sort of center the hitbox on the top edge of the original hitbox, with the top edges lining up exactly
            return new Rectangle(OriginalHitbox.Center.X - ReducedWidth / 2, OriginalHitbox.Y, ReducedWidth, ReducedHeight);
        }
    }
}
