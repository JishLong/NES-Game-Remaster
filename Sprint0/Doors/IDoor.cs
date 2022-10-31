using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Doors
{
    public interface IDoor
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
