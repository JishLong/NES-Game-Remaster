using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Character
{
    public class GoriyaBoomerangSprite: AnimatedSprite
    {
        public GoriyaBoomerangSprite() : base(3, 12)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.BoomerangProj;
    }
}

