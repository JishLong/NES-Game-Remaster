using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;

namespace Sprint0.Enemies.Interfaces
{
    public interface IEnemy : ICharacter
    {
        void TakeDamage(int damage);
        void Freeze();
        void Unfreeze();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
        void Destroy();
    }
}
