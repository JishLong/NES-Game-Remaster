using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Items
{
    public interface IItem : ICollidable
    {
        public void Draw(SpriteBatch sb);

        public void Update();
    }
}
