using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingRight : ISprite
    {
        // singleton instance
        private static PlayerMovingRight instance;

        private int animationFrame = 0;
        private readonly PlayerStateController stateController;
        private int spriteScale = 3;

        public static PlayerMovingRight GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerMovingRight(stateController);
            }

            return instance;
        }

        private PlayerMovingRight(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            var position = stateController.GetState().GetPosition();
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Color color = Color.White;

            if (stateController.GetState().IsDamaged())
            {
                color = Color.Red;
            }

            if (animationFrame < 15)
            {
                sourceRectangle = new Rectangle(35, 11, 15, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 16);
            }
            else
            {
                sourceRectangle = new Rectangle(52, 11, 15, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 16);
            }



            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, color);
        }

        public void Update()
        {
            if (animationFrame > 30)
            {
                animationFrame = 0;
            }
            else
            {
                animationFrame++;
            }
        }

        public void Reset()
        {
            animationFrame = 0;
        }
    }
}

