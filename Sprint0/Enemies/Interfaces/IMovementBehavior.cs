using Microsoft.Xna.Framework;
using Sprint0.Enemies.Utils;

namespace Sprint0.Enemies.Interfaces
{
    public interface IMovementBehavior
    {
        Vector2 Move(GameTime gameTime);
        EnemyUtils.Direction GetDirection();
    }
}
