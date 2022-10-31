using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class FlameProjectile : AbstractProjectile
    {
        public FlameProjectile(ICollidable user, Types.Direction direction) : 
            base(new FlameProjSprite(), user, direction, new Vector2(5, 5))
        {
            MaxFramesAlive = 100;
            AudioManager.GetInstance().PlayOnce(Resources.FlameShoot);
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if (FramesPassed < MaxFramesAlive / 3)
            {
                Position += Velocity;
            }
        }
    }
}
