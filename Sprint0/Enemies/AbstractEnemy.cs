using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Interfaces;
using Sprint0.Enemies.Utils;
using Sprint0.Sprites.Enemies;
using Sprint0.Sprites;

namespace Sprint0.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        // Combat related fields.
        protected int Health;  
        protected IStunBehavior StunBehavior;
        protected IMovementBehavior MovementBehavior;
        protected IAttackBehavior AttackBehavior;

        // Movement related fields.
        protected Vector2 Position;
        protected EnemyUtils.Direction Direction;
        protected int MovementSpeed;
        protected bool IsFrozen = false;

        // Sprite related fields.
        protected ISprite Sprite;
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
            IsFrozen = true;
        }

        public void Unfreeze()
        {
            IsFrozen = false;
        }
        public abstract void Destroy();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
    }
}
