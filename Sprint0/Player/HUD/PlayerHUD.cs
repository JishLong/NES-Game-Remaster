using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles.Player;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Sprint0.Levels;
using Sprint0.Assets;
using Sprint0.Sprites;
using Sprint0.Sprites.Items;

namespace Sprint0.Player.HUD
{
    public class PlayerHUD
    {
        // How big the text appears on the screen; bigger number = bigger elements
        private static readonly float TextScaling = 0.3f;

        private readonly LevelManager LevelManager;
        private readonly Player Player;
        private readonly HUDMap HUDMap;
        private readonly HUDHearts HUDHearts;

        private readonly Rectangle HUDArea;
        private readonly Rectangle PrimaryItemArea;
        private readonly Rectangle SecondaryItemArea;
        private readonly Vector2 LevelNamePosition;
        private readonly Vector2 RupeeCountPosition;
        private readonly Vector2 KeyCountPosition;
        private readonly Vector2 BombCountPosition;

        public PlayerHUD(LevelManager levelManager, Player player)
        {
            LevelManager = levelManager;
            Player = player;           
            HUDMap = new HUDMap(levelManager, Player);
            HUDHearts = new(Player);

            HUDArea = new(0, 0, GameWindow.DefaultScreenWidth, (int)(56 * GameWindow.ResolutionScale));
            PrimaryItemArea = new((int)(152 * GameWindow.ResolutionScale), (int)(24 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            SecondaryItemArea = new((int)(128 * GameWindow.ResolutionScale), (int)(24 * GameWindow.ResolutionScale),
                (int)(8 * GameWindow.ResolutionScale), (int)(16 * GameWindow.ResolutionScale));
            LevelNamePosition = new((int)(20 * GameWindow.ResolutionScale), (int)(7 * GameWindow.ResolutionScale));
            RupeeCountPosition = new((int)(96 * GameWindow.ResolutionScale), (int)(13 * GameWindow.ResolutionScale));
            KeyCountPosition = new((int)(96 * GameWindow.ResolutionScale), (int)(29 * GameWindow.ResolutionScale));
            BombCountPosition = new((int)(96 * GameWindow.ResolutionScale), (int)(37 * GameWindow.ResolutionScale));
        }

        public void Draw(SpriteBatch sb)
        {
            // HUD layout
            sb.Draw(ImageMappings.GetInstance().GuiSpriteSheet, Utils.LinkToCamera(HUDArea), ImageMappings.GetInstance().Hud, Color.White,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            // Level name and mini map
            string levelName = "Level-" + LevelManager.CurrentLevel.LevelID;
            sb.DrawString(FontMappings.GetInstance().MediumFont, levelName, Utils.LinkToCamera(LevelNamePosition), Color.White,
                0f, Vector2.Zero, GameWindow.ResolutionScale * TextScaling, SpriteEffects.None, 0.18f);
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
            ISprite ItemSprite = new SwordProjectileSprite(Types.Direction.UP);
            Rectangle SpriteDrawbox = ItemSprite.GetDrawbox(PrimaryItemArea.Location.ToVector2());
            Vector2 SpritePosition = Utils.CenterRectangles(PrimaryItemArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
            ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);

            // Secondary weapon
            ItemSprite = Player.Inventory.SelectedItem switch
            {
                Types.Item.BOW => new BowSprite(),
                Types.Item.WOODENBOOMERANG => new WoodenBoomerangSprite(),
                Types.Item.BOMB => new BombSprite(),
                Types.Item.BLUECANDLE => new BlueCandleSprite(),
                Types.Item.BLUEPOTION => new BluePotionSprite(),
                _ => null
            };
            if (ItemSprite != null) 
            {
                SpriteDrawbox = ItemSprite.GetDrawbox(SecondaryItemArea.Location.ToVector2());
                SpritePosition = Utils.CenterRectangles(SecondaryItemArea, SpriteDrawbox.Width, SpriteDrawbox.Height);
                ItemSprite.Draw(sb, Utils.LinkToCamera(SpritePosition), Color.White, 0.18f);
            }

            // Item counts
            sb.DrawString(FontMappings.GetInstance().MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.RUPEE), 
                Utils.LinkToCamera(RupeeCountPosition), Color.White, 0f, Vector2.Zero, GameWindow.ResolutionScale * TextScaling, 
                SpriteEffects.None, 0.18f);
            sb.DrawString(FontMappings.GetInstance().MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.KEY), 
                Utils.LinkToCamera(KeyCountPosition), Color.White, 0f, Vector2.Zero, GameWindow.ResolutionScale * TextScaling, 
                SpriteEffects.None, 0.18f);
            sb.DrawString(FontMappings.GetInstance().MediumFont, "X" + Player.Inventory.GetAmount(Types.Item.BOMB), 
                Utils.LinkToCamera(BombCountPosition), Color.White, 0f, Vector2.Zero, GameWindow.ResolutionScale * TextScaling, 
                SpriteEffects.None, 0.18f);     
        }

        public void Update()
        {
            HUDMap.Update();
        }
    }
}
