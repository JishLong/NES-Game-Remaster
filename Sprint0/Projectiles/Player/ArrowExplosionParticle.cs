using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowExplosionParticle : AbstractProjectile
    {
        public ArrowExplosionParticle(ICollidable user, Types.Direction direction) :
            base(new ArrowExplosionProjectileSprite(), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = 10;
            Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
        }

        public override bool IsFromPlayer()
        {
            return true;
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
