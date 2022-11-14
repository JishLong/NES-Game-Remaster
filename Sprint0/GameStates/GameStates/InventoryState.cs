using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryState : AbstractGameState
    {
        private Vector2 textPosition;

        public InventoryState(Game1 game) : base(game)
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryStateMappings(Game, this)),
            };     
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.GetInstance().Move(Types.Direction.UP, (int)(44 * Utils.GameScale));
            Rectangle r = new Rectangle((int)Camera.GetInstance().Position.X, (int)Camera.GetInstance().Position.Y, Utils.GameWidth, (int)(176 * Utils.GameScale));
            sb.Draw(Resources.ScreenCover, r, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 0.2f);

            Vector2 textSize = Resources.MediumFont.MeasureString("Epic inventory will go here");
            textPosition = new Vector2(Camera.GetInstance().Position.X + Utils.GameWidth / 2 - textSize.X / 2,
                Camera.GetInstance().Position.Y + 176 * Utils.GameScale / 2 - textSize.Y / 2);
            //sb.DrawString(Resources.MediumFont, "Paul was here", textPosition, Color.White, 0f, new Vector2(0, 0), 1f,
            //    SpriteEffects.None, 0.19f);

            Vector2 inventoryLoc = new Vector2((int)Camera.GetInstance().Position.X + 95, (int)Camera.GetInstance().Position.Y + 30);
            sb.DrawString(Resources.MediumFont, "INVENTORY", inventoryLoc, Color.Red, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.15f);

            Vector2 selectLoc = new Vector2((int)Camera.GetInstance().Position.X + 40, (int)Camera.GetInstance().Position.Y + 210);
            sb.DrawString(Resources.MediumFont, "USE B BUTTON \n FOR THIS", selectLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.15f);



            Rectangle itemOutline = new Rectangle((int)Camera.GetInstance().Position.X + 170, (int)Camera.GetInstance().Position.Y + 105, Utils.GameWidth / 9, (int)(34 * Utils.GameScale));
            Rectangle itemInline = new Rectangle((int)Camera.GetInstance().Position.X + 175, (int)Camera.GetInstance().Position.Y + 108, Utils.GameWidth / 10, (int)(32 * Utils.GameScale));
            sb.Draw(Resources.ScreenCover, itemOutline, null, Color.Blue,
               0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            sb.Draw(Resources.ScreenCover, itemInline, null, Color.Black,
                0f, Vector2.Zero, SpriteEffects.None, 0.17f);



            Rectangle allOutline = new Rectangle((int)Camera.GetInstance().Position.X + 345, (int)Camera.GetInstance().Position.Y + 90, Utils.GameWidth / 2, (int)(60 * Utils.GameScale));
            Rectangle allInline = new Rectangle((int)Camera.GetInstance().Position.X + 350, (int)Camera.GetInstance().Position.Y + 95, Utils.GameWidth / 2 - 10, (int)(57 * Utils.GameScale));
            sb.Draw(Resources.ScreenCover, allOutline, null, Color.Blue,
               0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            sb.Draw(Resources.ScreenCover, allInline, null, Color.Black,
                0f, Vector2.Zero, SpriteEffects.None, 0.17f);

            Camera.GetInstance().Move(Types.Direction.DOWN, (int)(176 * Utils.GameScale)); 
            Game.Player.HUD.Draw(sb);
            Camera.GetInstance().Move(Types.Direction.UP, (int)(132 * Utils.GameScale));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
