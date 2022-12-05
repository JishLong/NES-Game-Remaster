using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Entities;

namespace Sprint0.Blocks
{
    public interface IBlock : ICollidable, IEntity
    {      
        bool IsWall { get; }

        void Draw(SpriteBatch sb);

        void Update();
    }
}
