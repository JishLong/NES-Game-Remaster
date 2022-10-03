using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class HeartSprite : AnimatedSprite
    {
        public HeartSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet()
        {
            return Resources.HeartSpriteSheet;
        }
    }
}
