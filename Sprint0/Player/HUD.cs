using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Player
{
    public class HUD: Inventory
    {
        int numGems;
        int numKeys;
        int numBombs;
        int numHearts;

        public HUD() 
        { 
        }

        public void Draw(SpriteBatch sb) 
        {
            Vector2 CameraPosition = Camera.GetInstance().Position;

            Rectangle HUDArea = new Rectangle((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(56 * Utils.GameScale));
 
            Vector2 lifeLOC = new Vector2((int)CameraPosition.X + 555, (int)CameraPosition.Y + 15);

            

            sb.Draw(Resources.GuiSpriteSheet, HUDArea, Resources.HUD, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);
            
            //Life
            int heartXOffset = 556;
            for (int i = 0; i < numHearts; i++)
            {
                Rectangle LIFEArea = new Rectangle((int)CameraPosition.X + heartXOffset, (int)CameraPosition.Y + 60, Utils.GameWidth / 33, (int)(8 * Utils.GameScale));
                sb.Draw(Resources.ItemsSpriteSheet, LIFEArea, Resources.Heart, Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                heartXOffset += 25;
            }
        }

        public void Update(IPlayer player) 
        {
            numGems = player.Inventory.GetAmount(Types.Item.RUPEE);
            numKeys = player.Inventory.GetAmount(Types.Item.KEY);
            numBombs = player.Inventory.GetAmount(Types.Item.BOMB);
            numHearts = player.Health;

        }
    }
}
