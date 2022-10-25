using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Projectiles
{
    public interface IProjectile : ICollidable
    {
        void DeathAction();

        void Draw(SpriteBatch sb);

        bool IsFromPlayer();

        bool IsTimeUp();

        void Update();
    }
}
