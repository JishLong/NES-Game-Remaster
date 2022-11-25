using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Utils;
using Sprint0.Sprites;
using Sprint0.Entities;

namespace Sprint0.Items
{
    public abstract class AbstractItem : IItem
    {
        public Vector2 Position { get; set; }

        private readonly ISprite Sprite;
        private readonly Types.Item ItemType;
        
        // For entity system
        public IEntity Parent { get; set; }
        public string Name { get; set; }

        protected AbstractItem(ISprite sprite, Vector2 position, Types.Item itemType)
        {
            Position = position;
            Sprite = sprite;
            ItemType = itemType;

            Name = "unnamed";
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, ItemLayerDepth);
        }

        public Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public virtual void Update()
        {
            Sprite.Update();
        }

        public Types.Item GetItemType() 
        {
            return ItemType;
        }
    }
}
