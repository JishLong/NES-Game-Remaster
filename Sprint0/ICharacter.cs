using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public interface ICharacter
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
