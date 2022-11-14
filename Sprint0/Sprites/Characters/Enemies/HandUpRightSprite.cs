using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class HandUpRightSprite : AbstractAnimatedSprite
    {
        public HandUpRightSprite() : base(2, 16) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Hand;
    }
}
