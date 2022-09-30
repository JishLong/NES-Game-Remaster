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

namespace Sprint0.Sprites.Npcs
{
    public class BombProjSprite : INpcSprite
    {
        private Texture2D Sheet;

        private int Width = 8;
        private int Height = 16;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovAnimation;
        private int AnimationSpd = 1;

        public BombProjSprite()
        {
            Sheet = Resources.LinkItemsSpriteSheet;
            MovAnimation = new Animation(Width, Height, AnimationSpd);
            MovAnimation.AddFrame(129, 185);
            // Frame size for explosion is larger than bomb
            MovAnimation.AddFrame(138, 185, 16, 16);
            MovAnimation.AddFrame(155, 185, 16, 16);
            MovAnimation.AddFrame(172, 185, 16, 16);
        }
        public void Update(GameTime gameTime)
        {
            MovAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Target = new Rectangle((int)position.X, (int)position.Y, Width * SpriteScale, Height * SpriteScale);
            Source = MovAnimation.CurrentRect();
            if (MovAnimation.CurrentFrame == 0 & false)
            {
                // TODO: draw logic
            }
            else
            {
                sb.Draw(Sheet, Target, Source, Color.White);
            }
        }

    }
}