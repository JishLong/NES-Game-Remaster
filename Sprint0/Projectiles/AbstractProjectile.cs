using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Player;

namespace Sprint0.Projectiles
{
    public abstract class AbstractProjectile : IProjectile
    {
        protected ISprite Sprite;
        protected ICollidable User;
        public Vector2 Position { get; set; }
        public int Damage { get; protected set; }
        protected Vector2 Velocity;

        /* [FramesAlive]: the number of game frames this projectile should ideally last for
         * [FramesPassed]: the number of game frames that this projectile has been alive (and updated) for
         */
        protected int MaxFramesAlive, FramesPassed;

        protected AbstractProjectile(ISprite sprite, ICollidable user, Types.Direction direction, Vector2 movementSpeed)
        {
            Sprite = sprite;
            User = user;
            Velocity = Utils.DirectionToVector(direction) * movementSpeed;

            Rectangle TempHitbox = sprite.GetDrawbox(Vector2.Zero);
            Position = Utils.LineUpEdges(user.GetHitbox(), TempHitbox.Width, TempHitbox.Height, direction);
            Damage = 0;

            MaxFramesAlive = 0;
            FramesPassed = 0;
        }    

        public virtual void DeathAction() 
        {
            // Nothing here! But nice that it doesn't necessarily have to be declared in concrete classes!
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

        public virtual bool IsFromPlayer()
        {
            if (User != null) return User is IPlayer;
            else return false;
        }

        public virtual Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public virtual bool IsTimeUp()
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
