using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Sprint0.Collision;

namespace Sprint0.Projectiles
{
    public abstract class AbstractProjectile : IProjectile
    {
        protected ISprite Sprite;
        protected ICollidable User;
        protected Vector2 Position, Velocity;

        /* [FramesAlive]: the number of game frames this projectile should ideally last for
         * [FramesPassed]: the number of game frames that this projectile has been alive (and updated) for
         */
        protected int MaxFramesAlive, FramesPassed;

        protected AbstractProjectile(ISprite sprite, ICollidable user, Vector2 position, Vector2 movementSpeed, Types.Direction direction)
        {
            Sprite = sprite;
            User = user;
            Position = position;
            Velocity = Utils.DirectionToVector(direction) * movementSpeed;
            MaxFramesAlive = 100;
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
            return false;
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
