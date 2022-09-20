using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class PlayerFacingDownward : ISprite
    {
        private readonly Texture2D spriteSheet;
        private readonly int spriteScale = 2;

        public PlayerFacingDownward()
        {
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1, 11, 15, 15);
            destinationRectangle = new Rectangle(10, 10, spriteScale * 15, spriteScale * 15);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update(int screenW, int screenH)
        {
            throw new NotImplementedException();
        }
    }
}

