using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Collision;

namespace Sprint0.Characters
{
    public interface ICharacter : ICollidable
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
