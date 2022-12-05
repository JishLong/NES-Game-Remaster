using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.Collision;
using Sprint0.Player;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Types;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionParticle : AbstractProjectile
    {
        public BombExplosionParticle(ICollidable user, Direction direction) :
            base(new BombExplosionProjectileSprite(), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;        
            Damage = 4;
            if (user is BombProjectile || user is MarioFireballProjectile)
            {
                Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
                AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().BombExplode);

                ProjectileManager PM = ProjectileManager.GetInstance();

                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.LEFT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.RIGHT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.UP);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.DOWN);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.UPLEFT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.UPRIGHT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.DOWNLEFT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.DOWNRIGHT);
            }     
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
