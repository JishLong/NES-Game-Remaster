using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;

namespace Sprint0.Characters.Npcs
{
    public interface INpc : ICharacter
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
        void Destroy();
    }
}
