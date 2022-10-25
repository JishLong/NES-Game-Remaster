using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public BlueArrowProjectile(Vector2 position, Types.Direction direction) :
            base(new BlueArrowProjSprite(direction), null, position, new Vector2(15, 15), direction)
        {
            MaxFramesAlive = 40;
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
            Sprite.Draw(sb, Position, Color.White);
        }
    }
}
