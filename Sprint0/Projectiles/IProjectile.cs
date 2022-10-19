using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using System;

namespace Sprint0.Projectiles
{
    public interface IProjectile : ICollidable
    {
        void DeathAction();

        void Draw(SpriteBatch sb);

        bool FromPlayer();

        bool TimeIsUp();

        void Update();
    }
}
