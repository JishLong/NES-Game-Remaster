using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class MarioFireballProjectile : AbstractProjectile
    {
        public MarioFireballProjectile(ICollidable user, Types.Direction direction) :
            base(new BossProjectileSprite(), user, direction, 
                new Vector2(10.0f / 3 * GameWindow.ResolutionScale, 10.0f / 3 * GameWindow.ResolutionScale))
        {
            MaxFramesAlive = 100;
            Damage = 1;
            Rectangle TempHitbox = Sprite.GetHitbox(Vector2.Zero);

            Position = Utils.CenterRectangles(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height);

            //AudioManager.GetInstance().PlayOnce(Resources.MarioFireball);
        }

        public override void DeathAction()
        {
            ProjectileManager PM = ProjectileManager.GetInstance();

            PM.AddProjectile(Types.Projectile.BOMB_EXPLOSION_PARTICLE, this, Types.Direction.NO_DIRECTION);
        }
    }
}
