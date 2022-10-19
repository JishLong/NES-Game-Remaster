using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombProjectile : AbstractProjectile
    {
        public BombProjectile(Vector2 position) : base(position, Vector2.Zero, Types.Direction.UP)
        {
            Sprite = new BombProjSprite();
            FramesAlive = 100;       
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.BOMBEXPLOSIONPROJ, Position, Types.Direction.UP);
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
