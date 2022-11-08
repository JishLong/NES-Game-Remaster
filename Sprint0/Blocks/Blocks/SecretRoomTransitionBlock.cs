using Microsoft.Xna.Framework;
using Sprint0.Levels.Utils;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class SecretRoomTransitionBlock: AbstractBlock
    {
        LevelResources LevelResources;
        public SecretRoomTransitionBlock(Vector2 position) : base(new WhiteBarsSprite(), position, true) 
        {
            LevelResources = LevelResources.GetInstance();
        }
        public override Rectangle GetHitbox()
        {
            Rectangle drawBox = Sprite.GetDrawbox(Position);
            return new Rectangle(drawBox.X, drawBox.Y - LevelResources.BlockHeight, drawBox.Width, drawBox.Height);
        }
    }
}
