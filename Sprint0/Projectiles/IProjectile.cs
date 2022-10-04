using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.Projectiles
{
    public interface IProjectile
    {
        void Update();

        void Draw(SpriteBatch sb);

        Boolean TimeIsUp();
    }
}
