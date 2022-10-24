using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Blocks
{
    public interface IBlock : ICollidable
    {      
        void Draw(SpriteBatch sb);

        bool IsWall();

        void Update();
    }
}
