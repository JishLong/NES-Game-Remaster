using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class FlameProjectile : AbstractProjectile
    {
        public FlameProjectile(Vector2 position, Types.Direction direction) : 
            base(new FlameProjSprite(), null, position, new Vector2(5, 5), direction)
        {
            MaxFramesAlive = 100;  
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

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
