using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class GoombaLaserProjectile : AbstractProjectile
    {
        public GoombaLaserProjectile(ICollidable user, Types.Direction direction) :
            base(new GoombaLaserProjSprite(direction), user, direction, new Vector2(30, 30))
        {
            MaxFramesAlive = 100;
            Damage = 1000;
            Rectangle TempHitbox = Sprite.GetDrawbox(Vector2.Zero);

            Position = Utils.CenterRectangles(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height);

            AudioManager.GetInstance().PlayOnce(Resources.GoombaLaserHum);
        }

        public override void DeathAction()
        {

        }
    }
}
