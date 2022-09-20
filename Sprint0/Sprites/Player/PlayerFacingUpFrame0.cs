using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class PlayerFacingUpFrame0 : ISprite
    {
        private readonly int spriteScale = 3;
        private readonly Vector2 position;

        public PlayerFacingUpFrame0(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(69, 11, 15, 15);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 15);

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

