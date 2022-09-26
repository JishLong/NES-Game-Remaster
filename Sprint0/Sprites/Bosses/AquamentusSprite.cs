using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Bosses
{
    public class AquamentusSprite : IBossSprite
    {
        private Texture2D Sheet;

        private int Width = 24;
        private int Height = 32;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovAnimation;
        private int AnimationSpd = 1;

        public AquamentusSprite()
        {
            Sheet = Resources.BossEnemiesSpriteSheet;
            MovAnimation = new Animation(Width, Height, AnimationSpd);
            MovAnimation.AddFrame(1, 11);
            MovAnimation.AddFrame(26, 11);
            MovAnimation.AddFrame(51, 11);
            MovAnimation.AddFrame(76, 11);
        }
        public void Update(GameTime gameTime)
        {
            MovAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Target = new Rectangle((int)position.X, (int)position.Y, Width * SpriteScale, Height * SpriteScale);
            Source = MovAnimation.CurrentRect();

            if (false)
            {
                //todo
            }
            else
            {
                sb.Draw(Sheet, Target, Source, Color.White);

            }
        }
    }
}