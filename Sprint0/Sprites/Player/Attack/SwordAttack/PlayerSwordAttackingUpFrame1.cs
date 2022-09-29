using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class PlayerSwordAttackingUpFrame1 : ISprite
    {
        private readonly int spriteScale = 3;
        private readonly Vector2 position;

        public PlayerSwordAttackingUpFrame1(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(112, 97, 16, 28);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 36, spriteScale * 16, spriteScale * 28);

            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

