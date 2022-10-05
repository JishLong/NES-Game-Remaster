﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Bosses
{
    public class DodongoRightSprite : IBossSprite
    {
        private Texture2D Sheet;

        private int Width = 30;
        private int Height = 15;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovAnimation;
        private int AnimationSpd = 1;

        public DodongoRightSprite()
        {
            Sheet = Resources.BossEnemiesSpriteSheet;
            MovAnimation = new Animation(Width, Height, AnimationSpd);
            MovAnimation.AddFrame(69, 58);
            MovAnimation.AddFrame(102, 58);
        }
        public void Update(GameTime gameTime)
        {
            MovAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch sb, Vector2 position)
        {
            Target = new Rectangle((int)position.X, (int)position.Y, Width * SpriteScale, Height * SpriteScale);
            Source = MovAnimation.CurrentRect();
            Vector2 origin = new Vector2(0, 0);

            sb.Draw(Sheet, Target, Source, Color.White);
        }
    }
}