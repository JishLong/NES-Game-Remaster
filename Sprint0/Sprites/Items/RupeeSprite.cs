using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class RupeeSprite : AnimatedSprite
    {
        public RupeeSprite() : base(2, 8)
        {
            
        }

        protected override Texture2D GetSpriteSheet()
        {
            return Resources.RupeeSpriteSheet;
        }
    }
}
