using Microsoft.Xna.Framework;
using Sprint0.Sprites.Bosses;

namespace Sprint0.Projectiles.Character_Projectiles
{
    public class BossProjectile : AbstractProjectile
    {
        public BossProjectile(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            FramesAlive = 180;
            FramesPassed = 0;

            Sprite = new AquamentusFlameSprite();
        }
    }
}
