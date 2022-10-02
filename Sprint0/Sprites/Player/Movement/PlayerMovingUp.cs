using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingUp : ISprite
    {
        // singleton instance
        private static PlayerMovingUp instance;

        private int animationFrame = 0;
        private readonly PlayerStateController stateController;
        private int spriteScale = 3;

        public static PlayerMovingUp GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerMovingUp(stateController);
            }

            return instance;
        }

        private PlayerMovingUp(PlayerStateController stateController)
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
                sourceRectangle = new Rectangle(71, 11, 12, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 12, spriteScale * 16);
            }
            else
            {
                sourceRectangle = new Rectangle(88, 11, 12, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 12, spriteScale * 16);
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

