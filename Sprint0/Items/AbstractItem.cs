using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Items
{
    public class AbstractItem : IItem
    {
        // Sprite
        protected ISprite Sprite;

        // Coordinates and dimensions
        protected Vector2 Position;

        protected AbstractItem(Vector2 position)
        {
            Position = position;
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

        public void Update()
        {
            Sprite.Update();
        }
    }
}
