using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Bosses.Interfaces;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Bosses.Behaviors
{
    public class AquamentusFlameBehavior : IBossAttackBehavior
    {
        private IBoss Boss;
        //private IWeapon Boomerang;
        private float ProjectileSpeed;
        public AquamentusFlameBehavior(IBoss boss, float projectileSpeed)
        {
            Boss = boss;
        }
        public void Attack(Vector2 position, Direction direction)
        {

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch sb)
        {

        }
    }
}
