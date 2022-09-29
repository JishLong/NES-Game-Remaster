using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingLeft : ISprite
    {
        // singleton instance
        private static PlayerMovingLeft instance;

        private int animationFrame = 0;
        private readonly PlayerStateController stateController;
        private int spriteScale = 3;

        public static PlayerMovingLeft GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerMovingLeft(stateController);
            }

            return instance;
        }

        private PlayerMovingLeft(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            var position = stateController.GetState().GetPosition();
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

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



            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
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

