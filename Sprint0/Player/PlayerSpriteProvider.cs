using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player
{
    public class PlayerSpriteProvider
    {
        private readonly PlayerStateController stateController;
        private ISprite currentSprite = new PlayerFacingDownwardFrame0();
        private int animationFrame = 0;

        public PlayerSpriteProvider(PlayerStateController stateController, Game1 game)
        {
            this.stateController = stateController;
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
                    this.currentSprite = new PlayerFacingDownwardFrame1();
                }
                else
                {
                    this.currentSprite = new PlayerFacingDownwardFrame0();
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

