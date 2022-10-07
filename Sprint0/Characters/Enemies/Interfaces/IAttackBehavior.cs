using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.Interfaces
{
    public interface IAttackBehavior
    {
        void Attack(Vector2 position, Direction direction);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
