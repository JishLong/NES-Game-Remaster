using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites
{
    public class MouseCursorSprite : AbstractSprite
    { 
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CursorSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Cursor;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Cursor;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            return 4;
        }

        protected override int GetAnimationSpeed()
        {
            return 6;
        }

        public override Rectangle GetDrawbox(Vector2 position)
        {
            Rectangle frame = GetFirstFrame();

            return new Rectangle((int)(position.X + (GetPixelOffset().X * 3)),
                (int)(position.Y + (GetPixelOffset().Y * 3)),
                (int)(frame.Width * 3),
                (int)(frame.Height * 3));

        }
    }
}
