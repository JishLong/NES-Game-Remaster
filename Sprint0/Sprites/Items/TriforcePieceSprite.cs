using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class TriforcePieceSprite : AnimatedSprite
    {
        public TriforcePieceSprite() : base(2, 8)
        {
 
        }

        protected override Texture2D GetSpriteSheet()
        {
            return Resources.TriforcePieceSpriteSheet;
        }
    }
}
