using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Input;
using System.Collections.Generic;

namespace Sprint0.GameStates.GameStates
{
    public class InventoryState : AbstractGameState
    {
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
            sb.Draw(Resources.ScreenCover, r, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
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
