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
        private IEntity Parent;
        private string Name = "unnamed";

        protected AbstractBlock (ISprite sprite, Vector2 position, bool isWall) 
        {
            IsWall = isWall;

            Sprite = sprite;
            Position = position; 
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, BlockLayerDepth);
        }

        public virtual Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }

        public virtual void Update()
        {
            Sprite.Update();
        }
        public IEntity GetParent()
        {
            return Parent;
        }

        public void SetParent(IEntity entity)
        {
            Parent = entity;
        }
        public virtual string GetName()
        {
            return Name;
        }

        public virtual void SetName(string value)
        {
            Name = value;
        }
    }
}
