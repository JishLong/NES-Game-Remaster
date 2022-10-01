using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Weapons
{
    public class BoomerangSprite : IWeaponSprite
    {
        private Texture2D Sheet;

        private int Width = 5;
        private int Height = 8;
        private Vector2 Origin;
        private int SpriteScale = 3;

        private Rectangle Target;
        private Rectangle Source;

        private Animation MovingAnim;
        private double AnimSpeed = 4;

        public BoomerangSprite()
        {
            Sheet = Resources.DungeonEnemySpriteSheet;

            MovingAnim = new Animation(Width, Height, AnimSpeed);
            MovingAnim.AddFrame(291, 15, 5, 8);
            MovingAnim.AddFrame(299, 15, 8, 8);
            MovingAnim.AddFrame(308, 17, 8, 5);
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
            Origin.Y = Source.Height / 2;

            sb.Draw(Sheet, Target, Source, Color.White, 0f, origin: Origin, effects: SpriteEffects.None, 0f);
        }
    }
}
