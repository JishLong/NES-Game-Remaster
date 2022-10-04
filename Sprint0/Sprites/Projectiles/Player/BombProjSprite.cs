using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BombProjSprite : AnimatedSprite
    {
        public BombProjSprite() : base(4, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.BombWeapon;
    }
}
