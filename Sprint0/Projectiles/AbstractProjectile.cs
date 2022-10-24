using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Sprint0.Collision;

namespace Sprint0.Projectiles
{
    /* A default implementation of an IProjectile - cannot be instantiated
     */
    public abstract class AbstractProjectile : IProjectile
    {
        protected ISprite Sprite;
        protected ICollidable User;

        protected Vector2 Position, Velocity;

        /* [FramesAlive]: the number of game frames this projectile should ideally last for
         * [FramesPassed]: the number of game frames that this projectile has been alive (and updated) for
         */
        protected int FramesAlive, FramesPassed;

        protected AbstractProjectile(Vector2 position, Vector2 movementSpeed, Types.Direction direction, ICollidable user)
        {
            Position = position;
            Velocity = Utils.DirectionToVector(direction) * movementSpeed;
            FramesPassed = 0;
            User = user;
        }    

        public virtual void DeathAction() 
        {
            // Nothing here! But nice that it doens't necessarily have to be declared in concrete classes!
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if (Sprite != null) Sprite.Draw(sb, Position);
        }

        public virtual bool FromPlayer()
        {
            return false;
        }

        public virtual Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public virtual bool TimeIsUp()
        {
            return FramesPassed > FramesAlive;
        }

        public virtual void Update()
        {
            Sprite.Update();
            FramesPassed++;
            Position += Velocity;
        }
    }
}
