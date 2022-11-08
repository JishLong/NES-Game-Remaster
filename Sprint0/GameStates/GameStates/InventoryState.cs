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

        public InventoryState()
        {
            Controllers ??= new List<IController>()
            {
                new AudioController(),
                new KeyboardController(KeyboardMappings.GetInstance().GetInventoryStateMappings(Game, this)),
            };     
        }

        public override void Draw(SpriteBatch sb)
        {
            Camera.Move(Types.Direction.DOWN, (int)(44 * Utils.GameScale));
            Rectangle r = new Rectangle((int)Camera.GetOffset().X, (int)Camera.GetOffset().Y, Utils.GameWidth, (int)(176 * Utils.GameScale));
            sb.Draw(Resources.ScreenCover, r, null, Color.Black, 0, Vector2.Zero, SpriteEffects.None, 0.2f);

            Vector2 textSize = Resources.MediumFont.MeasureString("Epic inventory will go here");
            textPosition = new Vector2(Camera.GetOffset().X + Utils.GameWidth / 2 - textSize.X / 2,
                Camera.GetOffset().Y + 176 * Utils.GameScale / 2 - textSize.Y / 2);
            sb.DrawString(Resources.MediumFont, "Epic inventory will go here", textPosition, Color.White, 0f, new Vector2(0, 0), 1f,
                SpriteEffects.None, 0.19f);

            Camera.Move(Types.Direction.UP, (int)(176 * Utils.GameScale)); 
            Game.Player.HUD.Draw(sb);
            Camera.Move(Types.Direction.DOWN, (int)(132 * Utils.GameScale));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
