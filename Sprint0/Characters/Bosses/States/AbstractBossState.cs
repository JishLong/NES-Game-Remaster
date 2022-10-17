using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters.Bosses.States
{
    public abstract class AbstractBossState : IBossState
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
