using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Items
{
    public class AbstractItem : IItem
    {
        // Sprite
        protected ISprite sprite;

        // Coordinates and dimensions
        protected Vector2 Position;
        protected int Width, Height;

        protected AbstractItem(Vector2 position)
        {
            Position = position;
            Width = 64;
            Height = 64;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, (int)Position.X, (int)Position.Y, Width, Height);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
