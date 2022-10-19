using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);

        private float Rotation;

        public ArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction)
        {
            Sprite = new ArrowProjSprite();
            FramesAlive = 20;
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

        public override Rectangle GetHitbox()
        {
            // Incorrect for now - also needs to rotate
            return Sprite.GetDrawbox(Position);
        }  
    }
}
