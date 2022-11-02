using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected readonly ISprite Sprite;
        protected Vector2 Position;
        private readonly bool BlockIsWall;

        protected AbstractBlock (ISprite sprite, Vector2 position, bool isWall) 
        {
            Sprite = sprite;
            Position = position;
            BlockIsWall = isWall;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, 1f);
        }

        public virtual Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public bool IsWall()
        {
            return BlockIsWall;
        }

        public virtual void Update()
        {
            Sprite.Update();
        }   
    }
}
