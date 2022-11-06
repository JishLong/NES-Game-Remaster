using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Utils;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public SwordProjectile(Vector2 position, Types.Direction direction) :
            base(new SwordProjSprite(direction), null, position, new Vector2(10, 10), direction)
        {
            MaxFramesAlive = 1000;
            Direction = direction;
        }

        public override void DeathAction()
        {
            ProjectileManager PM = ProjectileManager.GetInstance();
            Rectangle r = Resources.SwordFlameProjDown;
            Vector2 ProjPosition = Utils.CenterOnEdge(Sprite.GetDrawbox(Position), (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale),
                Direction);

            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, ProjPosition, Types.Direction.UPLEFT, null);
            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, ProjPosition, Types.Direction.UPRIGHT, null);
            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, ProjPosition, Types.Direction.DOWNLEFT, null);
            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, ProjPosition, Types.Direction.DOWNRIGHT, null);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, ProjectileLayerDepth);
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
