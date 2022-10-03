using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Stationary;
using Microsoft.Xna.Framework;

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
            this.currentSprite = new PlayerFacingDown();
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
                currentSprite = new PlayerFacingUp();
            }
            else if (state.FacingDown())
            {
                currentSprite = new PlayerFacingDown();
            }
            else if (state.FacingRight())
            {
                currentSprite = new PlayerFacingRight();
            }
            else
            {
                currentSprite = new PlayerFacingLeft();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (stateController.GetState().IsDamaged())
            {
                currentSprite.Draw(sb, stateController.GetState().GetPosition(), Color.Red);
            }
            else
            {
                currentSprite.Draw(sb, stateController.GetState().GetPosition());
            }
        }

        // resets to the default sprite
        public void Reset()
        {
            this.currentSprite = new PlayerFacingDown();
        }
    }
}
