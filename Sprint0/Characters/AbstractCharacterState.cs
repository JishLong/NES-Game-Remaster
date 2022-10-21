using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters
{
    public abstract class AbstractCharacterState : ICharacterState
    {
        protected ISprite Sprite;
        public abstract void Attack();
        public abstract void Move();
        public abstract void Freeze();
        public abstract void ChangeDirection();

        public abstract void Update(GameTime gameTime);
        public void Draw(SpriteBatch sb, Vector2 position, Color color)
        {
            Sprite.Draw(sb, position, color);
        }

        public Rectangle GetHitbox(Vector2 position)
        {
            return Sprite.GetDrawbox(position);
        }
    }
}
