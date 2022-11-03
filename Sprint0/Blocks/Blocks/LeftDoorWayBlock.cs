using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;
using Sprint0.Levels.Utils;

namespace Sprint0.Blocks.Blocks
{
    public class LeftDoorWayBlock : AbstractBlock
    {
        // North and South doorways sit on the boundary between 2 blocks.
        // This class and its counterpart are the solution to that issue.
        LevelResources LevelResources;
        public LeftDoorWayBlock(Vector2 position) : base(new BlueWallSprite(), position, true)
        {
            LevelResources = LevelResources.GetInstance();
        }

        public override Rectangle GetHitbox()
        {
            int width = LevelResources.BlockWidth;
            int height = LevelResources.BlockHeight;
            return new Rectangle((int)Position.X, (int)Position.Y, width/2, height);
        }

        public override void Draw(SpriteBatch sb)
        {
            // Nothing to draw.
        }
    }
}

