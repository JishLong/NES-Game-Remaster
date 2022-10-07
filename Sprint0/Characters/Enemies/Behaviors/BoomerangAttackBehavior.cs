using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using Sprint0.Enemies.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.Interfaces;

namespace Sprint0.Enemies.Behaviors
{
    public class BoomerangAttackBehavior : IAttackBehavior
    {
        private IEnemy Enemy;
        private IWeapon Boomerang;
        private float ProjectileSpeed;

        public BoomerangAttackBehavior(IEnemy enemy, float projectileSpeed, double attackFreq = 3000)
        {
            Enemy = enemy;
            Boomerang = new NoWeapon();
            ProjectileSpeed = projectileSpeed;
        }

        public void Attack(Vector2 position, Direction direction)
        {
            //Enemy.Freeze();
            Boomerang = new BoomerangWeapon(position, direction, ProjectileSpeed);
        }

        public void Update(GameTime gameTime)
        {
            if (!Boomerang.IsEnabled())
            {
                Boomerang = new NoWeapon(); // Assign the weapon to the none type.
               // Enemy.Unfreeze();
            }
            Boomerang.Update(gameTime);
        }

        public void Draw(SpriteBatch sb)
        {
            Boomerang.Draw(sb);
        }
    }
}
