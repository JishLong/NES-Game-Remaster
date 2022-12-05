using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Player;
using static Sprint0.Utils;

namespace Sprint0.Projectiles
{
    public abstract class AbstractProjectile : IProjectile
    {
        public Vector2 Position { get; set; }
        public int Damage { get; protected set; }

        protected ISprite Sprite;
        protected ICollidable User;
        protected Vector2 Velocity;

        /* [MaxFramesAlive]: the number of game frames this projectile should ideally last for
         * [FramesPassed]: the number of game frames that this projectile has been alive (and updated) for
         */
        protected int MaxFramesAlive, FramesPassed;

        protected AbstractProjectile(ISprite sprite, ICollidable user, Types.Direction direction, Vector2 movementSpeed)
        {
            Sprite = sprite;
            User = user;
            Velocity = DirectionToVector(direction) * movementSpeed;

            Rectangle TempHitbox = sprite.GetHitbox(Vector2.Zero);
            Position = AlignEdges(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height, direction);
            Damage = 0;

            MaxFramesAlive = 0;
            FramesPassed = 0;
        }

        public abstract void DeathAction();

        public virtual void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, LinkToCamera(Position), Color.White, ProjectileLayerDepth);
        }

        public virtual bool IsFromPlayer()
        {
            if (User != null) return User is IPlayer;
            else return false;
        }

        public virtual Rectangle GetHitbox()
        {
            return Sprite.GetHitbox(Position);
        }

        public virtual bool TimeIsUp()
        {
            return FramesPassed > MaxFramesAlive;
        }

        public virtual void Update()
        {
            FramesPassed++;
            Sprite.Update();
            Position += Velocity;
        }
    }
}
