using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class FlameProjectile : AbstractProjectile
    {
        public FlameProjectile(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            FramesAlive = 60;
            FramesPassed = 0;

            Sprite = new FlameProjectileSprite();
        }
        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;
            Position += Velocity;
        }
    }
}
