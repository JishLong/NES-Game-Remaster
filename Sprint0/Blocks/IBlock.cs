using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Blocks
{
    public interface IBlock : ICollidable
    {
        public bool IsPushable();
        public bool IsWalkable();
        public void Draw(SpriteBatch sb);

        public void Update();
    }
}
