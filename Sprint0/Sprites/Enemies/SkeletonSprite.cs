using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Enemies
{
    public class SkeletonSprite : IEnemySprite
    {

        private Texture2D Sheet;

        private int Width = 16;
        private int Height = 16;
        private int SpriteScale = 3;

        private Rectangle Target;   // Where to draw the sprite.
        private Rectangle Source;   // Where to draw from.

        private Animation MovingAnim;
        private int AnimSpeed = 1;
        public SkeletonSprite()
        {
            Sheet = Resources.DungeonEnemySpriteSheet;

            MovingAnim = new Animation(Width, Height, AnimSpeed);
            MovingAnim.AddFrame(1, 59);
            MovingAnim.AddFrame(1, 59);
        }
        public void Update(GameTime gameTime)
        {
            MovingAnim.Update(gameTime);
        }

        // Note: Skeleton is weird. It has an animation, but it reuses the same sprite 
        // by flipping it horizontally every frame...
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Target = new Rectangle((int)position.X, (int)position.Y, Width * SpriteScale, Height * SpriteScale);
            Source = MovingAnim.CurrentRect();
            Vector2 origin = new Vector2(Width/2,Height/2);

            if(MovingAnim.CurrentFrame == 0)
            {
                // Flip the Sprite.
                SpriteEffects flip = SpriteEffects.FlipHorizontally;
                sb.Draw(Sheet, Target, Source, Color.White, 0f, origin, flip, 0f);
            }
            else
            {
                // Draw it normally
                sb.Draw(Sheet, Target, Source, Color.White, 0f, origin, SpriteEffects.None, 0f);
            }
        }
    }
}
