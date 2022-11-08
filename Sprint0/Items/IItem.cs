using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Items
{
    public interface IItem : ICollidable
    {
        Vector2 Position { get; set; }

        void Draw(SpriteBatch sb);

        void Update();

        Types.Item GetItemType();
    }
}
