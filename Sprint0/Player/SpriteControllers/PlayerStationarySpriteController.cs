using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Stationary;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerStationarySpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerStationarySpriteController instance;

        private readonly PlayerStateController stateController;
        private ISprite currentSprite;

        private PlayerStationarySpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            // default sprite
            this.currentSprite = new PlayerFacingDown(stateController);
        }

        public static PlayerStationarySpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerStationarySpriteController(stateController);
            }

            return instance;
        }

        public void Update()
        {
            var state = stateController.GetState();

            if (state.FacingUp())
            {
                currentSprite = new PlayerFacingUp(stateController);
            }
            else if (state.FacingDown())
            {
                currentSprite = new PlayerFacingDown(stateController);
            }
            else if (state.FacingRight())
            {
                currentSprite = new PlayerFacingRight(stateController);
            }
            else
            {
                currentSprite = new PlayerFacingLeft(stateController);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            currentSprite.Draw(sb, 0, 0, 0, 0);
        }

        // resets to the default sprite
        public void Reset()
        {
            this.currentSprite = new PlayerFacingDown(stateController);
        }
    }
}

