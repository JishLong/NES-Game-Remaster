using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordFlameProjectile : AbstractProjectile
    {
        public SwordFlameProjectile(ICollidable user, Types.Direction direction) :
            base(new SwordFlameProjectileSprite(direction), user, direction, new Vector2(3, 3))
        {
            MaxFramesAlive = 20;

            Rectangle TempHitbox = Sprite.GetDrawbox(Vector2.Zero);
            Position = Utils.CenterRectangles(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height);
            Damage = 1;
        }

        public override bool IsFromPlayer()
        {
            return true;
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
