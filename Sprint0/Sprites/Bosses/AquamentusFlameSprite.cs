using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Bosses
{
    public class AquamentusFlameSprite : AnimatedSprite
    {
        public AquamentusFlameSprite() : base(4, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.BossProj;
    }
}
