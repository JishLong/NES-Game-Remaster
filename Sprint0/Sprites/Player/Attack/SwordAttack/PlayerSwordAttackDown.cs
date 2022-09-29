using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackDown : ISprite
    {
        // singleton instance
        private static PlayerSwordAttackDown instance;

        private readonly PlayerStateController stateController;
        private readonly int spriteScale = 3;

        public static PlayerSwordAttackDown GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackDown(stateController);
            }

            return instance;
        }

        private PlayerSwordAttackDown(PlayerStateController stateController)
        {
            this.stateController = stateController;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            var position = stateController.GetState().GetPosition();
            var frame = stateController.GetAttackFrame();
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (frame == 0)
            {
                sourceRectangle = new Rectangle(94, 47, 15, 15);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 15);
            }
            else if (frame == 1)
            {
                sourceRectangle = new Rectangle(111, 47, 15, 27);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 27);
            }
            else if (frame == 2)
            {
                sourceRectangle = new Rectangle(128, 47, 15, 23);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 23);
            }
            else
            {
                sourceRectangle = new Rectangle(145, 47, 15, 19);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 19);
            }

            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White);
        }
    }
}

