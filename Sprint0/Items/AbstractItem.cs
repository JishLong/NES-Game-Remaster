using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Utils;
using Sprint0.Sprites;

namespace Sprint0.Items
{
    public abstract class AbstractItem : IItem
    {
        private readonly ISprite Sprite;

        public Vector2 Position { get; set; }

        protected AbstractItem(ISprite sprite, Vector2 position)
        {
            Sprite = sprite;
            Position = position;
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
    }
}
