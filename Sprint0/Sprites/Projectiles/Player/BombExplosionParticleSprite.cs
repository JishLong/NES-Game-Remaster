using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BombExplosionParticleSprite : AbstractAnimatedSprite
    {
        public BombExplosionParticleSprite() : base(3, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.BombExplosionParticle;
    }
}
