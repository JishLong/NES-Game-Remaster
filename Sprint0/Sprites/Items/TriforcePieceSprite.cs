using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Player
{
    public class TriforcePieceSprite : AbstractAnimatedSprite
    {
        public TriforcePieceSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.ItemsSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.TriforcePiece;
    }
}
