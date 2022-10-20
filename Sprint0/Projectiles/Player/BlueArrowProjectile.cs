using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);

        public BlueArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction)
        {
            Sprite = new BlueArrowProjSprite(direction);
            FramesAlive = 40;           
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.ARROWEXPLOSIONPARTICLE, Sprite.GetDrawbox(Position).Location.ToVector2(), Types.Direction.UP);
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
