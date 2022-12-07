using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;

namespace Sprint0.Characters
{
    public interface ICharacterState
    {
        void Attack();

        void ChangeDirection();

        void Draw(SpriteBatch sb, Vector2 position, Color color);

        void Freeze(bool frozenForever);

        Rectangle GetHitbox(Vector2 position);

        void SetUp(Types.Direction direction = Types.Direction.NO_DIRECTION);

        void Unfreeze();
 
        void Update(GameTime gameTime);        
    }
}
