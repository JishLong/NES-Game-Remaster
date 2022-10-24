using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Items
{
    public interface IItem : ICollidable
    {
        void Draw(SpriteBatch sb);

        void Update();
    }
}
