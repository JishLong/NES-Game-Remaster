using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.SpriteControllers;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public class Player : IPlayer
    {
        private readonly PlayerStateController stateController;

        private readonly ISpriteController spriteController;

        public Player(Game1 game)
        {
            stateController = new PlayerStateController();
            spriteController = PlayerMasterSpriteController.GetInstance(stateController);
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            this.spriteController.Draw(spriteBatch);
        }

        public void Update()
        {
            spriteController.Update();
            stateController.Update();
        }

        public PlayerStateController GetStateController()
        {
            return this.stateController;
        }

        public Rectangle GetHitbox() 
        {
            return Rectangle.Empty;
        }
    }
}
