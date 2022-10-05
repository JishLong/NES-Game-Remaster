using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Npcs.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Npcs
{
    public abstract class AbstractNpc : INpc
    {
        // Combat related fields.
        public int Health { get; set; }

        // Movement related fields.
        public Vector2 Position;
        public Vector2 Direction;
        public string DirectionName;
        public int MovementSpeed;
        public bool CanMove;

        // Sprite related fields.
        public ISprite sprite { get; set; }

        public void TakeDamage(int damage)
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
    }
}
