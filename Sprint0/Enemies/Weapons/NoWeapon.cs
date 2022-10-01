using Sprint0.Sprites.Enemies;
using Sprint0.Sprites.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies.Weapons
{
    public class NoWeapon: IWeapon
    {
        public NoWeapon()
        {
            
        }

        public void Enable()
        {
            // Do nothing.
        }
        
        public void Disable()
        {
            // Do nothing.
        }

        public bool IsEnabled()
        {
            return true;
        }

        public void Update(GameTime gameTime)
        {
            // Do nothing.
        }
        public void Draw(SpriteBatch sb)
        {
            // Do nothing.
        }
    }
}
