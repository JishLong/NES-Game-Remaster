using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Bosses.Interfaces
{
    public interface IBoss
    {
        void TakeDamage(int damage);
        //void Freeze();
        //void Unfreeze();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
        void Destroy();
    }
}