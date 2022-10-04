using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies.Weapons
{

    public interface IWeapon
    {
        void Enable();
        void Disable();
        bool IsEnabled();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
