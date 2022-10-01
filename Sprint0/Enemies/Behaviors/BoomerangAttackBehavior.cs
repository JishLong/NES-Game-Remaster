using Sprint0.Enemies.Interfaces;
using static Sprint0.Enemies.Utils.EnemyUtils;
using Sprint0.Enemies.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemies.Behaviors
{

    public class BoomerangAttackBehavior : IAttackBehavior
    {
        private IEnemy Enemy;
        private double ElapsedTime;
        private double UpdateTimer;
        private Vector2 Position;
        private Direction Direction;
        private float ProjectileSpeed;
        private double ProjectileTimer;
        private IWeapon Boomerang;
        public BoomerangAttackBehavior(IEnemy enemy, float projectileSpeed, double attackFreq = 3000)
        {
            Enemy = enemy;
            Boomerang = new NoWeapon();
            ProjectileSpeed = projectileSpeed;
            ProjectileTimer = 1000;
            UpdateTimer = attackFreq;
        }
        public void Attack(Vector2 position, Direction direction)
        {
            Enemy.Freeze();
            Boomerang = new BoomerangWeapon(position, direction);

        }
        public void Update(GameTime gameTime)
        {
            if (!Boomerang.IsEnabled())
            {
                Boomerang = new NoWeapon(); // Assign the weapon to the none type.
                Enemy.Unfreeze();
            }
            Boomerang.Update(gameTime);
        }
        public void Draw(SpriteBatch sb)
        {
            Boomerang.Draw(sb);
        }
    }
}
