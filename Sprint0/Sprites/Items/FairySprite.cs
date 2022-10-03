using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class FairySprite : AnimatedSprite
    {
        public FairySprite() : base(2, 8)
        {
            
        }

        override protected Texture2D GetSpriteSheet() 
        {
            return Resources.FairySpriteSheet;
        }
    }
}
