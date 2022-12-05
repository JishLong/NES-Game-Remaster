using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* This block is essentially just an invisible trigger for transitioning between (normal) dungeon rooms;
     * The implementation of this can be explored in the collision handling system
     */
    public class RoomTransitionBlock : AbstractBlock
    {
        public RoomTransitionBlock(Vector2 position) : base(new BlueSandSprite(), position, true) { }

        public override Rectangle GetHitbox()
        {
            return Sprite.GetHitbox(Position);
        }
        public override void Draw(SpriteBatch sb)
        {
            // This block is invisible, so we simply won't draw anything
        }
    }
}
