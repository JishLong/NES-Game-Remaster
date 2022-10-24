using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(10, 10);

        public SwordProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction)
        {
            Sprite = new SwordProjSprite(direction);
            FramesAlive = 1000;
        }

        public override void DeathAction()
        {
            ProjectileManager PM = ProjectileManager.GetInstance();
            Vector2 ProjPosition = new Vector2(Position.X + Sprite.GetDrawbox(Position).Width / 2,
                Position.Y + Sprite.GetDrawbox(Position).Height / 2);

            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.UPLEFT);
            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.UPRIGHT);
            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.DOWNLEFT);
            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.DOWNRIGHT);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White);
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
