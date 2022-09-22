using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;

namespace Sprint0.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public int health { get; set; }      // Health property
        public IEnemySprite sprite { get; set; }  // Sprite property 
        
        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy();
            }
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
        public abstract void Destroy();
    }
}
