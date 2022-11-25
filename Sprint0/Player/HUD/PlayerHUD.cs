using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Player;
using Sprint0.Sprites.Projectiles.Player;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Sprint0.Levels;

namespace Sprint0.Player.HUD
{
    public class PlayerHUD
    {        
        private readonly LevelManager LevelManager;
        private readonly Player Player;

        private readonly HUDMap HUDMap;
        private readonly HUDHearts HUDHearts;

        public PlayerHUD(LevelManager levelManager, Player player)
        {
            LevelManager = levelManager;
            Player = player;
            
            HUDMap = new HUDMap(levelManager, Player);
            HUDHearts = new(Player);
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 CameraPosition = Camera.GetInstance().Position;

            // Some positions for things on the HUD
            Rectangle HUDArea = new((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(56 * Utils.GameScale));
            Vector2 SecondaryItem = new((int)(128 * Utils.GameScale), (int)(24 * Utils.GameScale));
            Vector2 PrimaryItem = new((int)(152 * Utils.GameScale), (int)(24 * Utils.GameScale));
            Vector2 LevelName = new((int)(20 * Utils.GameScale + CameraPosition.X), (int)(7 * Utils.GameScale + CameraPosition.Y));
            Vector2 RupeeCount = new((int)(96 * Utils.GameScale + CameraPosition.X), (int)(13 * Utils.GameScale + CameraPosition.Y));
            Vector2 KeyCount = new((int)(96 * Utils.GameScale + CameraPosition.X), (int)(29 * Utils.GameScale + CameraPosition.Y));
            Vector2 BombCount = new((int)(96 * Utils.GameScale + CameraPosition.X), (int)(37 * Utils.GameScale + CameraPosition.Y));

            // HUD layout
            sb.Draw(Resources.GuiSpriteSheet, HUDArea, Resources.HUD, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            // Level name and mini map
            string levelName = "Level-" + LevelManager.CurrentLevel.LevelID;
            sb.DrawString(Resources.MediumFont, levelName, LevelName, Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);
            HUDMap.DrawPlayerLocation(sb);
            if (Player.Inventory.HasItem(Types.Item.COMPASS))
            {
                HUDMap.DrawBossLocation(sb);
            }
            if (Player.Inventory.HasItem(Types.Item.MAP))
            {
                HUDMap.DrawMap(sb);
            }

            // Health bar
            HUDHearts.Draw(sb);

            // Primary weapon
            new SwordProjSprite(Types.Direction.UP).Draw(sb, PrimaryItem, Color.White, 0.18f);

            // Secondary weapon
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

            // Item counts
            sb.DrawString(Resources.MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.RUPEE), RupeeCount, Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);
            sb.DrawString(Resources.MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.KEY), KeyCount, Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);
            sb.DrawString(Resources.MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.BOMB), BombCount, Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);     
        }

        public void Update()
        {
            HUDMap.Update();
        }
    }
}
