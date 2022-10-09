using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters.Enemies.States
{
    public abstract class AbstractEnemyState : IEnemyState
    {
        protected ISprite Sprite;
        public abstract void Attack();
        public abstract void Move();
        public abstract void Freeze();
        public abstract void ChangeDirection();
        public abstract void Update(GameTime gameTime);
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Sprite.Draw(sb, position);
        }
    }
}
