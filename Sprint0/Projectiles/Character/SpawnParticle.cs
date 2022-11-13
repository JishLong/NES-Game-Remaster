using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;
using Microsoft.Xna.Framework;

namespace Sprint0.Projectiles.Character
{
    public class SpawnParticle : AbstractProjectile
    {
        public SpawnParticle(ICollidable user) :
            base(new BombExplosionParticleSprite(), user, Types.Direction.NO_DIRECTION, Vector2.Zero)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;
            Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
