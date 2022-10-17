using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters.Bosses.States
{
    public interface IBossState
    {
        void Attack();
        void Move();
        void Freeze();
        void ChangeDirection();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, Vector2 position);
    }
}
