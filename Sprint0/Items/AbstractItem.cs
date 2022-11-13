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
        private IEntity Parent = null;  // Owning entity.
        private string Name = "unnamed";

        protected AbstractItem(ISprite sprite, Vector2 position, Types.Item itemType)
        {
            Position = position;
            
            Sprite = sprite;
            ItemType = itemType;
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

        public IEntity GetParent()
        {
            return Parent;
        }

        public void SetParent(IEntity entity)
        {
            Parent = entity;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string value)
        {
            Name = value;
        }
    }
}
