using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Levels;

namespace Sprint0.Characters
{
    public interface ICharacter : ICollidable
    {
        void Draw(SpriteBatch sb);

        void TakeDamage(Types.Direction damageSide, int damage, Room room);

        void Update(GameTime gameTime);

        public void location(Vector2 newLoc);

        public Vector2 GetPosition();
    }
}
