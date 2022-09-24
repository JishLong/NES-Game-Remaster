using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;

namespace Sprint0.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public int Health { get; set; }     // Health property

        public Vector2 Position;
        public Vector2 Direction;
        public int MovementSpeed;
        public bool CanMove;
        public IEnemySprite sprite { get; set; }  // Sprite property 
        
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
            this.CanMove = false;
        }

        public void Unfreeze()
        {
            this.CanMove = true;
        }

        public abstract void Destroy();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
    }
}
