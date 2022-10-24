using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordFlameProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(4, 4);

        public SwordFlameProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction, null)
        {
            Sprite = new SwordFlameProjSprite(direction);
            FramesAlive = 20;
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
