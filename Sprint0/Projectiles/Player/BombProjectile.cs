using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public BombProjectile(ICollidable user, Types.Direction direction) : 
            base(new BombProjSprite(), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = 100;
            Direction = direction;
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction);
        }
    }
}
