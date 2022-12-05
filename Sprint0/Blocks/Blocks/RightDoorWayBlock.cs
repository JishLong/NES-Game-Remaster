using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* North and South doorways sit on the boundary between 2 blocks.
     * This class and its counterpart are the solution to that issue.
     */
    public class RightDoorWayBlock : AbstractBlock
    {
        public RightDoorWayBlock(Vector2 position) : base(new BlueWallSprite(), position, true) { }

        public override Rectangle GetHitbox()
        {
            Rectangle DrawBox = Sprite.GetHitbox(Position);
            return new Rectangle((int)Position.X + DrawBox.Width / 2, (int)Position.Y, DrawBox.Width / 2, DrawBox.Height);
        }

        public override void Draw(SpriteBatch sb)
        {
            // This block is invisible, so we simply won't draw anything
        }
    }
}
