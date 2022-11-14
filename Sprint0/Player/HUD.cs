using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Player;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Player
{
    public class HUD: Inventory
    {
        int numGems;
        int numKeys;
        int numBombs;
        int numHearts;

        IPlayer Player;

        public HUD(IPlayer player) 
        {
            Player = player;
        }

        public void Draw(SpriteBatch sb) 
        {
            Vector2 CameraPosition = Camera.GetInstance().Position;

            Rectangle HUDArea = new Rectangle((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(56 * Utils.GameScale));
            Vector2 lifeLOC = new Vector2((int)CameraPosition.X + 555, (int)CameraPosition.Y + 15);
            Vector2 Life = new((int)(176 * Utils.GameScale + CameraPosition.X), (int)(32 * Utils.GameScale + CameraPosition.Y));
            Vector2 SecondaryItem = new((int)(128 * Utils.GameScale), (int)(24 * Utils.GameScale));
            Vector2 PrimaryItem = new((int)(152 * Utils.GameScale), (int)(24 * Utils.GameScale));



            sb.Draw(Resources.GuiSpriteSheet, HUDArea, Resources.HUD, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            if (Player.Inventory.SelectedItem == Types.Item.WOODEN_BOOMERANG)
                new WoodenBoomerangSprite().Draw(sb, SecondaryItem, Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BOMB)
                new BombSprite().Draw(sb, SecondaryItem, Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BOW)
                new BowSprite().Draw(sb, SecondaryItem, Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BLUE_CANDLE)
                new BlueCandleSprite().Draw(sb, SecondaryItem, Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BLUE_POTION)
                new BluePotionSprite().Draw(sb, SecondaryItem, Color.White, 0.18f);

            new SwordProjSprite(Types.Direction.UP).Draw(sb, PrimaryItem, Color.White, 0.18f);

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
