using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using System;

namespace Sprint0.Projectiles
{
    public interface IProjectile : ICollidable
    {
        void Update();

        void Draw(SpriteBatch sb);

        Boolean TimeIsUp();
    }
}
