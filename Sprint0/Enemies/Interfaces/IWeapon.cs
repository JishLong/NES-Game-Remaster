using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Enemies.Weapons
{

    public interface IWeapon
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
