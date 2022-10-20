using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Levels;

namespace Sprint0.Characters
{
    public interface ICharacter : ICollidable
    {
        void Draw(SpriteBatch sb);

        void TakeDamage(int damage, Room room);

        void Update(GameTime gameTime);
        
    }
}
