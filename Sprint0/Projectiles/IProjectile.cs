using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
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
