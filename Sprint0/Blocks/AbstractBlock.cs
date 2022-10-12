using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected ISprite Sprite;
        protected Vector2 Position;

        protected AbstractBlock (Vector2 position) 
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

        public Rectangle GetHitbox() 
        {
            return Sprite.GetDrawbox(Position);
        }
    }
}
