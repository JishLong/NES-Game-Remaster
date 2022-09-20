using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class PlayerFacingDownwardFrame0 : ISprite
    {
        private readonly int spriteScale = 3;

        public PlayerFacingDownwardFrame0()
        {
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1, 11, 15, 15);
            destinationRectangle = new Rectangle(10, 10, spriteScale * 15, spriteScale * 15);

            sb.Begin(samplerState: SamplerState.PointClamp);
            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White);
            sb.End();
        }

        public void Update(int screenW, int screenH)
        {
            throw new NotImplementedException();
        }
    }
}

