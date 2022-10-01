using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackLeft : ISprite
    {
        // singleton instance
        private static PlayerSwordAttackLeft instance;

        private readonly PlayerStateController stateController;
        private readonly int spriteScale = 3;

        public static PlayerSwordAttackLeft GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackLeft(stateController);
            }

            return instance;
        }

        private PlayerSwordAttackLeft(PlayerStateController stateController)
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
            Color color = Color.White;

            if (stateController.GetState().IsDamaged())
            {
                color = Color.Red;
            }

            if (frame == 0)
            {
                sourceRectangle = new Rectangle(94, 77, 15, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 16);
            }
            else if (frame == 1)
            {
                sourceRectangle = new Rectangle(111, 77, 27, 16);
                destinationRectangle = new Rectangle((int)position.X - 33, (int)position.Y, spriteScale * 27, spriteScale * 16);
            }
            else if (frame == 2)
            {
                sourceRectangle = new Rectangle(139, 78, 23, 16);
                destinationRectangle = new Rectangle((int)position.X - 24, (int)position.Y, spriteScale * 23, spriteScale * 16);
            }
            else
            {
                sourceRectangle = new Rectangle(163, 77, 19, 15);
                destinationRectangle = new Rectangle((int)position.X - 12, (int)position.Y, spriteScale * 19, spriteScale * 15);
            }

            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
        }
    }
}