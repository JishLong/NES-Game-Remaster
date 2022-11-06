using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Utils;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordFlameProjectile : AbstractProjectile
    {
        public SwordFlameProjectile(Vector2 position, Types.Direction direction) :
            base(new SwordFlameProjSprite(direction), null, position, new Vector2(4, 4), direction)
        {
            MaxFramesAlive = 20;
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
