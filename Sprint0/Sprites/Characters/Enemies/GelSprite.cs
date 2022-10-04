using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class GelSprite : AnimatedSprite
    {
        public GelSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Gel;
    }
}
