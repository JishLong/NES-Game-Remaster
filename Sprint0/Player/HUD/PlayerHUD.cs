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
            // Some positions for things on the HUD
            Rectangle HUDArea = new(0, 0, GameWindow.DefaultScreenWidth, (int)(56 * GameWindow.ResolutionScale));
            Vector2 SecondaryItem = new(128 * GameWindow.ResolutionScale, (int)(24 * GameWindow.ResolutionScale));
            Vector2 PrimaryItem = new(152 * GameWindow.ResolutionScale, (int)(24 * GameWindow.ResolutionScale));
            Vector2 LevelName = new((int)(20 * GameWindow.ResolutionScale), (int)(7 * GameWindow.ResolutionScale));
            Vector2 RupeeCount = new((int)(96 * GameWindow.ResolutionScale), (int)(13 * GameWindow.ResolutionScale));
            Vector2 KeyCount = new((int)(96 * GameWindow.ResolutionScale), (int)(29 * GameWindow.ResolutionScale));
            Vector2 BombCount = new((int)(96 * GameWindow.ResolutionScale), (int)(37 * GameWindow.ResolutionScale));

            // HUD layout
            sb.Draw(Resources.GuiSpriteSheet, Utils.LinkToCamera(HUDArea), Resources.HUD, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            // Level name and mini map
            string levelName = "Level-" + LevelManager.CurrentLevel.LevelID;
            sb.DrawString(Resources.MediumFont, levelName, Utils.LinkToCamera(LevelName), Color.White,
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
            new SwordProjSprite(Types.Direction.UP).Draw(sb, Utils.LinkToCamera(PrimaryItem), Color.White, 0.18f);

            // Secondary weapon
            if (Player.Inventory.SelectedItem == Types.Item.WOODENBOOMERANG)
                new WoodenBoomerangSprite().Draw(sb, Utils.LinkToCamera(SecondaryItem), Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BOMB)
                new BombSprite().Draw(sb, Utils.LinkToCamera(SecondaryItem), Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BOW)
                new BowSprite().Draw(sb, Utils.LinkToCamera(SecondaryItem), Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BLUECANDLE)
                new BlueCandleSprite().Draw(sb, Utils.LinkToCamera(SecondaryItem), Color.White, 0.18f);
            else if (Player.Inventory.SelectedItem == Types.Item.BLUEPOTION)
                new BluePotionSprite().Draw(sb, Utils.LinkToCamera(SecondaryItem), Color.White, 0.18f);

            // Item counts
            sb.DrawString(Resources.MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.RUPEE), Utils.LinkToCamera(RupeeCount), Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);
            sb.DrawString(Resources.MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.KEY), Utils.LinkToCamera(KeyCount), Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);
            sb.DrawString(Resources.MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.BOMB), Utils.LinkToCamera(BombCount), Color.White,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0.18f);     
        }

        public void Update()
        {
            HUDMap.Update();
        }
    }
}
