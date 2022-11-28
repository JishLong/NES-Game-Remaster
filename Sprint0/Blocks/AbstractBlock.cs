using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Utils;
using Sprint0.Sprites;
using Sprint0.Entities;

namespace Sprint0.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        public bool IsWall { get; private set;  }

        protected readonly ISprite Sprite;
        protected Vector2 Position;

        // For the entity system
        public IEntity Parent { get; set; }
        public string Name { get; set; }

        protected AbstractBlock (ISprite sprite, Vector2 position, bool isWall) 
        {
            IsWall = isWall;
            Sprite = sprite;
            Position = position;

            Name = "unnamed";
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, LinkToCamera(Position), Color.White, BlockLayerDepth);
        }

        public virtual Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public virtual void Update()
        {
            Sprite.Update();
        }
    }
}
