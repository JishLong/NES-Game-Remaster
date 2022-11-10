using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* Specifically used to trigger a transition out of the basement room back to the normal dungeon;
     * The implementation of this can be explored in the collision handling system
     */
    public class SecretRoomTransitionBlock: AbstractBlock
    {
        public SecretRoomTransitionBlock(Vector2 position) : base(new WhiteBarsSprite(), position, true) { }

        public override Rectangle GetHitbox()
        {
            Rectangle DrawBox = Sprite.GetDrawbox(Position);
            return new Rectangle(DrawBox.X, DrawBox.Y - DrawBox.Height, DrawBox.Width, DrawBox.Height);
        }
    }
}
