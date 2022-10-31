using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles
{
    public class BoomerangSprite : AbstractAnimatedSprite
    {
        public BoomerangSprite() : base(3, 6)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.BoomerangProj;
    }
}
