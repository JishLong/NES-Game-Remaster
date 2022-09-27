using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Npcs
{
    public interface INpcSprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, Vector2 position);
    }
}