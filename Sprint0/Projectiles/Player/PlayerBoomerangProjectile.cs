using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player
{
    public class PlayerBoomerangProjectile : AbstractProjectile
    {
        private bool IsReturning;

        public PlayerBoomerangProjectile(ICollidable player, Types.Direction direction) : 
            base(new BoomerangSprite(), player, GetPosition(player), new Vector2(5, 5), direction)
        {
            MaxFramesAlive = 75;
            IsReturning = false;
        }

        private static Vector2 GetPosition(ICollidable user)
        {
            Rectangle r = Resources.BoomerangProj;
            Rectangle ParticleHitbox = new Rectangle(r.X, r.Y, (int)(r.Width * Utils.GameScale), (int)(r.Height * Utils.GameScale));
            return Utils.CenterRectangles(user.GetHitbox(), ParticleHitbox);
        }

        public override bool IsFromPlayer()
        {
            return true;
        }

        public void ReturnBoomerang()
        {
            if (!IsReturning)
            {
                FramesPassed = MaxFramesAlive - FramesPassed;
                IsReturning = true;
            }
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;
            IsReturning = false;

            Vector2 EndPos = Utils.CenterRectangles(User.GetHitbox(), GetHitbox());

            if (FramesPassed < (MaxFramesAlive / 2))
            {
                Position += Velocity;
            }
            else if (FramesPassed >= MaxFramesAlive / 2)
            {
                Position += (EndPos - Position) / (MaxFramesAlive - FramesPassed);
            }
        }
    }
}
