using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class PlayerSpriteProvider
    {
        private PlayerStateController stateController;
        private ISprite currentSprite;
        private int animationFrame = 0;

        public PlayerSpriteProvider(PlayerStateController stateController, Game1 game)
        {
            this.stateController = stateController;
            spriteSheet = game.Content.Load<Texture2D>("Link+Items");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        // do we want an Update() method or just Draw()?
        public void Update()
        {
            if (stateController.GetState().FacingDown())
            {
                if(stateController.GetState().IsMoving() && animationFrame > 15)
                {
                    
                }
                else
                {

                }
            }
            animationFrame++;
        }
    }
}

