using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombProjectile : AbstractProjectile
    {
        public BombProjectile(Vector2 position) : 
            base(new BombProjSprite(), null, position, Vector2.Zero, Types.Direction.NO_DIRECTION)
        {
            MaxFramesAlive = 100;       
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.BOMB_EXPLOSION_PARTICLE, Position, Types.Direction.UP, null);
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
