using Sprint0.Enemies.Interfaces;
using static Sprint0.Enemies.Utils.EnemyUtils;
using Sprint0.Enemies.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemies.Behaviors
{

    public class BoomerangAttackBehavior : IAttackBehavior
    {
        private float ElapsedTime;
        private float UpdateTimer;
        private Direction Direction;
        private float ProjectileSpeed;
        private IWeapon Boomerang;
        public BoomerangAttackBehavior(float projectileSpeed, float attackFreq = 2000)
        { 
            ProjectileSpeed = projectileSpeed;
            UpdateTimer = attackFreq;
        }

        public void Attack(GameTime gameTime, Direction direction)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((ElapsedTime - UpdateTimer) > 0)
            {
                ElapsedTime = 0;
                Boomerang = new BoomerangWeapon();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            Boomerang.Draw(sb);

        }
    }
}
