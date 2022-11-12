using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters
{
    public interface ICharacterState
    {
        void Attack();

        void ChangeDirection();

        void Draw(SpriteBatch sb, Vector2 position, Color color);

        void Freeze(bool frozenForever);

        Rectangle GetHitbox(Vector2 position);

        void Move();

        void Unfreeze();
 
        void Update(GameTime gameTime);        
    }
}
