using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
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
            this.currentSprite = new PlayerFacingDown(stateController.GetState().GetPosition());
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
                currentSprite = new PlayerFacingUp(state.GetPosition());
            }
            else if (state.FacingDown())
            {
                currentSprite = new PlayerFacingDown(state.GetPosition());
            }
            else if (state.FacingRight())
            {
                currentSprite = new PlayerFacingRight(state.GetPosition());
            }
            else
            {
                currentSprite = new PlayerFacingLeft(state.GetPosition());
            }
        }

        public void Draw(SpriteBatch sb)
        {
            currentSprite.Draw(sb, 0, 0, 0, 0);
        }

        // resets to the default sprite
        public void Reset()
        {
            this.currentSprite = new PlayerFacingDown(stateController.GetState().GetPosition());
        }
    }
}

