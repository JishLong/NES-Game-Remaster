using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Entities;

namespace Sprint0.Items
{
    public interface IItem : ICollidable, IEntity
    {
        Vector2 Position { get; set; }

        void Draw(SpriteBatch sb);
        
        Types.Item GetItemType();

        void Update();       
    }
}
