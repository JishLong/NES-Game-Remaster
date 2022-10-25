using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class DeathParticle : AbstractProjectile
    {
        public DeathParticle(ICollidable user) :
            base(new DeathParticleSprite(), user, GetPosition(user), Vector2.Zero, Types.Direction.NO_DIRECTION)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;
        }

        private static Vector2 GetPosition(ICollidable user) 
        {
            Rectangle r = Resources.CharacterDeathParticle;
            Rectangle ParticleHitbox = new Rectangle(r.X, r.Y, (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale));
            return Utils.CenterRectangles(user.GetHitbox(), ParticleHitbox);
        }
    }
}
