using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters.Enemies.States
{
    public interface IEnemyState
    {
        void Attack();
        void Move();
        void Freeze();
        void ChangeDirection();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, Vector2 position);

        Rectangle GetHitbox(Vector2 position);
    }
}
