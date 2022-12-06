using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class GoombaLaserProjectile : AbstractProjectile
    {
        public GoombaLaserProjectile(ICollidable user, Types.Direction direction) :
            base(new SwordProjectileSprite(direction), user, direction, 
                new Vector2(30.0f / 3 * GameWindow.ResolutionScale, 30.0f / 3 * GameWindow.ResolutionScale))
        {
            MaxFramesAlive = 100;
            Damage = 1000;
            Rectangle TempHitbox = Sprite.GetHitbox(Vector2.Zero);

            Position = Utils.CenterRectangles(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height);

            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().SwordShoot);
        }

        public override void DeathAction()
        {

        }
    }
}
