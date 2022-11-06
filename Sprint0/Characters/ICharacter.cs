using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Levels;

namespace Sprint0.Characters
{
    public interface ICharacter : ICollidable
    {
        Vector2 Position { get; set; }

        int Damage { get; }

        void Draw(SpriteBatch sb);

        void Freeze();

        void TakeDamage(Types.Direction damageSide, int damage, Room room);

        void Update(GameTime gameTime);
    }
}
