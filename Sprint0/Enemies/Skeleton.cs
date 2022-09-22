using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Enemies
{
    public class Skeleton : AbstractEnemy
    {

        Vector2 Position;
        public Skeleton(Vector2 position)
        {
            this.Position = position;
            this.health = health;
            this.sprite = new Sprites.Enemies.SkeletonSprite();
        }   

        public override void Destroy()
        {
            // not sure what to do here yet...
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}
