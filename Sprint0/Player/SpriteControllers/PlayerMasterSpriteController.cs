using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.SpriteControllers;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;

namespace Sprint0.Player
{
    public class PlayerMasterSpriteController
    {
        private readonly PlayerStateController stateController;
        private ISprite currentSprite;
        private int animationFrame = 0;

        // other sprite controllers
        private readonly PlayerMovementSpriteController movementController;
        private readonly PlayerStationarySpriteController stationaryController;
        private readonly PlayerAttackingSpriteController attackingController;

        public PlayerMasterSpriteController(PlayerStateController stateController, Game1 game)
        {
            this.stateController = stateController;
            this.movementController = new PlayerMovementSpriteController(stateController);
            this.stationaryController = new PlayerStationarySpriteController(stateController);
            this.attackingController = new PlayerAttackingSpriteController(stateController);

            this.currentSprite = new PlayerFacingDownwardFrame0(stateController.GetState().GetPosition());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, 0, 0, 0, 0);
        }

        public void Update()
        {
            var state = stateController.GetState();

            if (state.IsMoving())
            {
                movementController.Update();
                this.currentSprite = movementController.GetSprite();
            }
            else
            {
                movementController.Reset();
                this.currentSprite = stationaryController.GetSprite();
            }            

            if (state.IsAttacking())
            {
                this.currentSprite = attackingController.GetSprite();
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
