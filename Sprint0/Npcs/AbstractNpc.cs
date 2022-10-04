using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Npcs.Interfaces;
using Sprint0.Sprites.Npcs;

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
        protected bool CanMove;

        // Sprite related fields.
        protected INpcSprite Sprite { get; set; }
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
        public abstract void Destroy();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
    }
}