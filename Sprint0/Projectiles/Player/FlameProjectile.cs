using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.Collision;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class FlameProjectile : AbstractProjectile
    {
        public FlameProjectile(ICollidable user, Types.Direction direction) : 
            base(new FlameProjectileSprite(), user, direction, new Vector2(5, 5))
        {
            MaxFramesAlive = 100;
            Damage = 1;
            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().FlameShoot);

            Rectangle TempHitbox = Sprite.GetDrawbox(Vector2.Zero);
            Position = Utils.CenterOnEdge(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height, direction);
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

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
