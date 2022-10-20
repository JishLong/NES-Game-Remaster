using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters
{
    public interface ICharacterState
    {
        void Attack();
        void Move();
        void Freeze();
        void ChangeDirection();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, Vector2 position, Color color);

        Rectangle GetHitbox(Vector2 position);
    }
}
