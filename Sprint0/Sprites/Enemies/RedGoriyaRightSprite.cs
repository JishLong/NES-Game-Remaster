using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.Enemies
{
    public class RedGoriyaRightSprite : IEnemySprite
    {
        private Texture2D Sheet;

        private int Width = 16;
        private int Height = 16;
        private Vector2 Origin;
        private int SpriteScale = 3;

        private Rectangle Target;   // Where to draw the sprite.
        private Rectangle Source;   // Where to draw from.

        private Animation MovingAnim;

        private float AnimSpeed = 1;
        public RedGoriyaRightSprite()
        {
            Sheet = Resources.DungeonEnemySpriteSheet;

            MovingAnim = new Animation(Width, Height, AnimSpeed);
            MovingAnim.AddFrame(257, 11, 13, 16);
            MovingAnim.AddFrame(275, 12, 14, 15);
        }

        public void Update(GameTime gameTime)
        {
            MovingAnim.Update(gameTime);
        }
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Source = MovingAnim.CurrentRect();
            Target = new Rectangle((int)position.X, (int)position.Y, Source.Width * SpriteScale, Source.Height * SpriteScale);

            // Set origin
            Origin.X = Source.Width / 2;
            Origin.Y = Source.Height / 2 ;

            sb.Draw(Sheet, Target, Source, Color.White, 0f, Origin, SpriteEffects.None, 0f);
           
        }
    }
}
