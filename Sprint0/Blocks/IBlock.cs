using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Blocks
{
    public interface IBlock : ICollidable
    {      
        bool IsWall { get; }

        void Draw(SpriteBatch sb);

        void Update();
    }
}
