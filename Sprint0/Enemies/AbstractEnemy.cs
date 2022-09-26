using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Interfaces;
using Sprint0.Sprites.Enemies;

namespace Sprint0.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        // Combat related fields.
        public int Health { get; set; }     
        public IStunBehavior StunBehavior;

        // Movement related fields.
        public Vector2 Position;
        public Vector2 Direction;
        public string DirectionName;
        public int MovementSpeed;
        public bool CanMove;
        
        // Sprite related fields.
        public IEnemySprite sprite { get; set; }  
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
