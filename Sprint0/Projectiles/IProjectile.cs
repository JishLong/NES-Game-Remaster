using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Projectiles
{
    public interface IProjectile : ICollidable
    {
        Vector2 Position { get; set; }

        int Damage { get; }

        void DeathAction();

        void Draw(SpriteBatch sb);

        bool IsFromPlayer();

        bool IsTimeUp();

        void Update();
    }
}
