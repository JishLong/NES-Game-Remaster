using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;

namespace Sprint0.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public int Health { get; set; }      // Health property
        public bool CanMove { get; set; }
        public IEnemySprite sprite { get; set; }  // Sprite property 
        
        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Destroy();
            }
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
        public abstract void Destroy();
    }
}
