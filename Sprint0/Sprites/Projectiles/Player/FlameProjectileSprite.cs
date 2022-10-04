using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class FlameProjectileSprite: AnimatedSprite
    {
        public FlameProjectileSprite() : base(4, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndItemsSheet;

        protected override Rectangle GetFirstFrame() => Resources.FlameProjectile;
    }
}
