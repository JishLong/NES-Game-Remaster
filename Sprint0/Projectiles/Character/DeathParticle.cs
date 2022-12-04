using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Character;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class DeathParticle : AbstractProjectile
    {
        public DeathParticle(ICollidable user) :
            base(new DeathProjectileSprite(), user, Types.Direction.NO_DIRECTION, Vector2.Zero)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;
            Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
