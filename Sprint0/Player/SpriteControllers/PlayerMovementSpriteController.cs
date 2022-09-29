﻿using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites.Player;
using Sprint0.Sprites.Player.Movement;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerMovementSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerMovementSpriteController instance;

        private readonly PlayerStateController stateController;
        private ISprite currentSprite;

        private PlayerMovementSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            this.currentSprite = PlayerMovingDown.GetInstance(stateController);
        }

        public static PlayerMovementSpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerMovementSpriteController(stateController);
            }

            return instance;
        }

        public void Draw(SpriteBatch sb)
        {
            currentSprite.Draw(sb, 0, 0, 0, 0);
        }

        public void Update()
        {
            var state = stateController.GetState();
            currentSprite.Update();

            if (state.FacingUp())
            {
                currentSprite = PlayerMovingUp.GetInstance(stateController);
            }
            else if (state.FacingDown())
            {
                currentSprite = PlayerMovingDown.GetInstance(stateController);
            }
            else if (state.FacingRight())
            {
                currentSprite = PlayerMovingRight.GetInstance(stateController);
            }
            else
            {
                currentSprite = PlayerMovingLeft.GetInstance(stateController);
            }

          
        }

        public void Reset()
        {
            currentSprite = PlayerMovingDown.GetInstance(stateController);
        }
    }
}

