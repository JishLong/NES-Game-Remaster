using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player
{
    public class PlayerSpriteController
    {
        private readonly PlayerStateController stateController;
        private ISprite currentSprite;
        private int animationFrame = 0;

        public PlayerSpriteController(PlayerStateController stateController, Game1 game)
        {
            this.stateController = stateController;
            this.currentSprite = new PlayerFacingDownwardFrame0(stateController.GetState().GetPosition());
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            currentSprite.Draw(spriteBatch, screenWidth, screenHeight);
        }

        // do we want an Update() method or just Draw()?
        public void Update()
        {
            var state = stateController.GetState();
            if (state.FacingDown())
            {
                if (state.IsMoving() && animationFrame > 15)
                {
                    this.currentSprite = new PlayerFacingDownwardFrame1(state.GetPosition());
                }
                else
                {
                    this.currentSprite = new PlayerFacingDownwardFrame0(state.GetPosition());
                }
            }

            if(animationFrame > 30)
            {
                animationFrame = 0;
            }
            else
            {
                animationFrame++;
            }
        }
    }
}
