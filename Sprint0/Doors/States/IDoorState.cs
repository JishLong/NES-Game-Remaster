using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Doors.States
{
    public interface IDoorState
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
