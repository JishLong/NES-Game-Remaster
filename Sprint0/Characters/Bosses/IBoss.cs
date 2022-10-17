using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;

namespace Sprint0.Characters.Bosses
{
    public interface IBoss : ICharacter
    {
        void TakeDamage(int damage);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
        void Destroy();
    }
}
