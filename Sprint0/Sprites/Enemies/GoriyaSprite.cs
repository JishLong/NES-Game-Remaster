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
    public class GoriyaSprite : IEnemySprite
    {
        private Texture2D Sheet;

        private int Width = 16;
        private int Height = 16;
        private Vector2 Origin;
        private int SpriteScale = 3;

        private Rectangle Target;   // Where to draw the sprite.
        private Rectangle Source;   // Where to draw from.

        private Animation RightAnim;
        private Animation LeftAnim;
        private Animation UpAnim;
        private Animation DownAnim;
        public Animation CurrentAnim;

        private int AnimSpeed = 1;
        public GoriyaSprite(IEnemy enemy) 
        {
            Sheet = Resources.DungeonEnemySpriteSheet;

            RightAnim = new Animation(Width, Height, AnimSpeed);
            RightAnim.AddFrame(257, 11, 13, 16);
            RightAnim.AddFrame(275, 12, 14, 15);

            LeftAnim = new Animation(Width, Height, AnimSpeed);
            LeftAnim.AddFrame(257, 11, 13, 16);
            LeftAnim.AddFrame(275, 12, 14, 15);

            UpAnim = new Animation(Width, Height, AnimSpeed);
            UpAnim.AddFrame(241,11,13,16);
            UpAnim.AddFrame(241,11,13,16);

            DownAnim = new Animation(Width, Height, AnimSpeed);
            DownAnim.AddFrame(224,11,13,16);
            DownAnim.AddFrame(224,11,13,16);

            CurrentAnim = RightAnim; // Start moving to the right.
        }

        public void SetAnim(string directionName)
        {
            switch (directionName)
            {
                case "UP":
                    CurrentAnim = UpAnim;
                    break;
                case "RIGHT":
                    CurrentAnim = RightAnim;
                    break;
                case "DOWN":
                    CurrentAnim = DownAnim;
                    break;
                case "LEFT":
                    CurrentAnim = LeftAnim;
                    break;
            }
        }
        public void Update(GameTime gameTime)
        {
            CurrentAnim.Update(gameTime);
        }
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            if(CurrentAnim.CurrentFrame == 0)
            {
                // Flip the Sprite.
                SpriteEffects flip = SpriteEffects.FlipHorizontally;
                Vector2 origin = new Vector2(0, 0);
                sb.Draw(Sheet, Target, Source, Color.White, 0f, origin, flip, 0f);
            }
            else
            {
                // Draw it normally
                sb.Draw(Sheet, Target, Source, Color.White);
            }
        }
    }
}
