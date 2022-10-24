using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Types;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(10, 10);
        private readonly Types.Direction Direction;

        public SwordProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction, null)
        {
            Sprite = new SwordProjSprite(direction);
            FramesAlive = 1000;
            Direction = direction;
        }

        public override void DeathAction()
        {
            ProjectileManager PM = ProjectileManager.GetInstance();
            Rectangle r = Resources.SwordFlameProjDown;
            Rectangle ProjHitbox = new Rectangle(r.X, r.Y, (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale));
            Vector2 ProjPosition = Utils.CenterOnEdge(Sprite.GetDrawbox(Position), ProjHitbox, Direction);

            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.UPLEFT, null);
            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.UPRIGHT, null);
            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.DOWNLEFT, null);
            PM.AddProjectile(Types.Projectile.SWORDFLAMEPROJ, ProjPosition, Types.Direction.DOWNRIGHT, null);
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
