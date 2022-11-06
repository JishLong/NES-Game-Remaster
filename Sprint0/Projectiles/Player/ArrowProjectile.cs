using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Utils;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public ArrowProjectile(Vector2 position, Types.Direction direction) :
            base(new ArrowProjSprite(direction), null, position, new Vector2(15, 15), direction)
        {
            MaxFramesAlive = 20;
            Direction = direction;
        }

        public override void DeathAction()
        {
            Rectangle r = Resources.ArrowExplosionParticle;

            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.ARROW_EXPLOSION_PARTICLE,
                Utils.CenterOnEdge(Sprite.GetDrawbox(Position), (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale), Direction),
                Direction, null);
        }

        public override bool IsFromPlayer()
        {
            return true;
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, ProjectileLayerDepth);
        } 
    }
}
