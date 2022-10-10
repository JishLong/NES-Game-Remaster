using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles;

namespace Sprint0.Player.SpriteControllers
{
    public class PlayerArrowAttackingSpriteController : ISpriteController
    {
        // singleton instance
        private static PlayerArrowAttackingSpriteController instance;

        private readonly PlayerStateController stateController;
        private ISprite currentSprite;

        //me
        Texture2D sheet = Resources.LinkAndItemsSheet;
        Rectangle arrow;
        Rectangle screenLoc = new Rectangle(10, 190, 16, 5);
        int linkX;
        int linkY;
        int xOffset = 20;
        int yOffset = 30;
        int maxY = 600;
        int minY = -600;
        int maxX = 600;
        int minX = -600;
        bool direction;
        SpriteEffects effect;

        public static PlayerArrowAttackingSpriteController GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerArrowAttackingSpriteController(stateController);
            }
            return instance;
        }

        private PlayerArrowAttackingSpriteController(PlayerStateController stateController)
        {
            this.stateController = stateController;
            currentSprite = PlayerSwordAttackDown.GetInstance();


        }

        public void Update()
        {
            var state = stateController.GetState();

            if (state.FacingDown())
            {
                if (yOffset >= maxY)
                {
                    yOffset = 30;
                }
                direction = true;
                screenLoc = new Rectangle(3, 185, 5, 16);
                effect = SpriteEffects.FlipVertically;
                Vector2 linkLoc = stateController.GetState().GetPosition();
                linkX = (int)linkLoc.X + xOffset;
                linkY = (int)linkLoc.Y + yOffset;
                arrow = new Rectangle(linkX, linkY + yOffset, 3 * 5, 3 * 16);
                yOffset += 15;
            }
            else if (state.FacingUp())
            {
                if (yOffset <= minY)
                {
                    yOffset = 30;
                }
                direction = true;
                screenLoc = new Rectangle(3, 185, 5, 16);
                effect = SpriteEffects.None;
                Vector2 linkLoc = stateController.GetState().GetPosition();
                linkX = (int)linkLoc.X + xOffset;
                linkY = (int)linkLoc.Y + yOffset;
                arrow = new Rectangle(linkX, linkY - yOffset, 3 * 5, 3 * 16);
                yOffset -= 15;
            }
            else if (state.FacingRight())
            {
                if (xOffset >= maxX)
                {
                    xOffset = 30;
                }
                direction = false;
                screenLoc = new Rectangle(10, 190, 16, 5);
                effect = SpriteEffects.None;
                Vector2 linkLoc = stateController.GetState().GetPosition();
                linkX = (int)linkLoc.X + xOffset;
                linkY = (int)linkLoc.Y + yOffset;
                arrow = new Rectangle(linkX + xOffset, linkY, 3 * 16, 3 * 5);
                xOffset += 15;
            }
            // when facing left
            else
            {
                if (xOffset <= minX)
                {
                    xOffset = 30;
                }
                direction = false;
                screenLoc = new Rectangle(10, 190, 16, 5);
                effect = SpriteEffects.FlipHorizontally;
                Vector2 linkLoc = stateController.GetState().GetPosition();
                linkX = (int)linkLoc.X + xOffset;
                linkY = (int)linkLoc.Y + yOffset;
                arrow = new Rectangle(linkX - xOffset, linkY, 3 * 16, 3 * 5);
                xOffset -= 15;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, stateController.GetState().GetPosition());
            if (direction)
            {
                arrow = new Rectangle(linkX, linkY, 3 * 5, 3 * 16);
            }
            else
            {
                arrow = new Rectangle(linkX, linkY, 3 * 16, 3 * 5);
            }
            spriteBatch.Draw(sheet, arrow, screenLoc, Color.Black, 0, new Vector2(0, 0), effect, 0.5f);
        }
    }
}