using System;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class PlayerSpriteProvider
    {
        private PlayerStateController stateController;
        private ISprite currentSprite;

        public PlayerSpriteProvider(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Draw()
        {
            //TODO: implement
        }

        // do we want an Update() method or just Draw()?
        public void Update()
        {
            //TODO: implement
        }
    }
}

