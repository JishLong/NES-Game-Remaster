using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackUp : ISprite
    {
        // singleton instance
        private static PlayerSwordAttackUp instance;

        private readonly PlayerStateController stateController;
        private readonly int spriteScale = 3;

        public static PlayerSwordAttackUp GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackUp(stateController);
            }

            return instance;
        }

        private PlayerSwordAttackUp(PlayerStateController stateController)
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
                sourceRectangle = new Rectangle(95, 109, 15, 15);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 15);
            }
            else if (frame == 1)
            {
                sourceRectangle = new Rectangle(112, 97, 16, 28);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 36, spriteScale * 16, spriteScale * 28);
            }
            else if (frame == 2)
            {
                sourceRectangle = new Rectangle(130, 98, 12, 27);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 33, spriteScale * 12, spriteScale * 27);
            }
            else
            {
                sourceRectangle = new Rectangle(147, 106, 12, 19);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 9, spriteScale * 12, spriteScale * 19);
            }

            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White);
        }
    }
}

