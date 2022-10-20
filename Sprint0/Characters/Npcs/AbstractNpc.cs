using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Npcs;
using Sprint0.Levels;
using Sprint0.Sprites;

namespace Sprint0.Npcs
{
    public abstract class AbstractNpc : INpc
    {
        // Combat related fields.
        protected int Health { get; set; }

        // Movement related fields.
        protected Vector2 Position;
        protected Vector2 Direction;
        protected string DirectionName;
        protected int MovementSpeed;
        protected bool CanMove = false;

        // Sprite related fields.
        protected ISprite sprite { get; set; }

        public void TakeDamage(int damage, Room room)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Destroy();
            }
        }

        public void Freeze()
        {
            CanMove = false;
        }

        public void Unfreeze()
        {
            CanMove = true;
        }

        // need for projectile logic
        // public abstract bool IsProjectile();
        public abstract void Destroy();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);

        public Rectangle GetHitbox() 
        {
            return sprite.GetDrawbox(Position);
        }
    }
}
