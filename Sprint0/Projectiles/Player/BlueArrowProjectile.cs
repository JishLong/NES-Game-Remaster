using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);

        private float Rotation;

        public BlueArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction)
        {
            Sprite = new BlueArrowProjSprite();
            FramesAlive = 40;
            Rotation = Utils.DirectionToRadians(direction);               
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(
                Types.Projectile.ARROWEXPLOSIONPROJ, Position, Types.Direction.UP);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, Rotation);
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
