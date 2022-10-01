using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Stationary
{
    public class PlayerFacingUp : ISprite
    {
        private readonly int spriteScale = 3;
        private readonly PlayerStateController stateController;

        public PlayerFacingUp(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Vector2 position = stateController.GetState().GetPosition();

            Color color = Color.White;

            if (stateController.GetState().IsDamaged())
            {
                color = Color.Red;
            }

            sourceRectangle = new Rectangle(71, 11, 12, 16);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 12, spriteScale * 16);

            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, color);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

