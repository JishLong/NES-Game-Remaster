using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;

namespace Sprint0.Player.HUD
{
    public class PlayerHUD : Inventory
    {
        int numGems;
        int numKeys;
        int numBombs;
        int numHearts;

        private HUDMap HUDMap;
        private Player Player;

        public PlayerHUD(LevelManager levelManager, Player player)
        {
            Player = player;
            HUDMap = new HUDMap(levelManager, Player);
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 CameraPosition = Camera.GetInstance().Position;

            Rectangle HUDArea = new Rectangle((int)CameraPosition.X, (int)CameraPosition.Y, Utils.GameWidth, (int)(44 * Utils.GameScale));
            //mini map, gems, keys, bombs, "A" key attack, "B" key attack, Life
            Rectangle MAPArea = new Rectangle((int)CameraPosition.X + 30, (int)CameraPosition.Y + 20, Utils.GameWidth / 3, (int)(30 * Utils.GameScale));
            Rectangle gemsAREA = new Rectangle((int)CameraPosition.X + 300, (int)CameraPosition.Y + 15, Utils.GameWidth / 28, (int)(10 * Utils.GameScale));
            Rectangle keysAREA = new Rectangle((int)CameraPosition.X + 300, (int)CameraPosition.Y + 48, Utils.GameWidth / 28, (int)(10 * Utils.GameScale));
            Rectangle bombAREA = new Rectangle((int)CameraPosition.X + 297, (int)CameraPosition.Y + 82, Utils.GameWidth / 28, (int)(10 * Utils.GameScale));
            Rectangle bAttackArea = new Rectangle((int)CameraPosition.X + 400, (int)CameraPosition.Y + 29, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
            Rectangle bOutline = new Rectangle((int)CameraPosition.X + 398, (int)CameraPosition.Y + 23, Utils.GameWidth / 11, (int)(34 * Utils.GameScale));
            Rectangle bInline = new Rectangle((int)CameraPosition.X + 401, (int)CameraPosition.Y + 26, Utils.GameWidth / 12, (int)(32 * Utils.GameScale));
            Rectangle aAttackArea = new Rectangle((int)CameraPosition.X + 475, (int)CameraPosition.Y + 29, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
            Rectangle aOutline = new Rectangle((int)CameraPosition.X + 472, (int)CameraPosition.Y + 23, Utils.GameWidth / 11, (int)(34 * Utils.GameScale));
            Rectangle aInline = new Rectangle((int)CameraPosition.X + 474, (int)CameraPosition.Y + 26, Utils.GameWidth / 12, (int)(32 * Utils.GameScale));
            Vector2 bLoc = new Vector2((int)CameraPosition.X + 420, (int)CameraPosition.Y - 8);
            Vector2 aLoc = new Vector2((int)CameraPosition.X + 495, (int)CameraPosition.Y - 8);
            Vector2 gemLoc = new Vector2((int)CameraPosition.X + 335, (int)CameraPosition.Y + 10);
            Vector2 bombLoc = new Vector2((int)CameraPosition.X + 335, (int)CameraPosition.Y + 80);
            Vector2 lifeLOC = new Vector2((int)CameraPosition.X + 555, (int)CameraPosition.Y + 15);

            //hud background
            sb.Draw(Resources.ScreenCover, HUDArea, null, Color.Black,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);
            //mini map
            if (Player.Inventory.HasItem(Types.Item.MAP))
            {
                HUDMap.Draw(sb, MAPArea);
            }
            //gems
            sb.Draw(Resources.ItemsSpriteSheet, gemsAREA, Resources.Rupee, Color.GhostWhite,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            sb.DrawString(Resources.MediumFont, "X" + numGems, gemLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.18f);
            //keys
            sb.Draw(Resources.ItemsSpriteSheet, keysAREA, Resources.Key, Color.YellowGreen,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            Vector2 keyLoc = new Vector2((int)CameraPosition.X + 335, (int)CameraPosition.Y + 44);
            sb.DrawString(Resources.MediumFont, "X" + numKeys, keyLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.18f);
            //bombs
            sb.Draw(Resources.ItemsSpriteSheet, bombAREA, Resources.Bomb, Color.SteelBlue,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            sb.DrawString(Resources.MediumFont, "X" + numBombs, bombLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.18f);
            //"B" attack + outline
            sb.Draw(Resources.ScreenCover, bOutline, null, Color.Blue,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            sb.Draw(Resources.ScreenCover, bInline, null, Color.Black,
                0f, Vector2.Zero, SpriteEffects.None, 0.17f);
            sb.Draw(Resources.WeaponsAndProjSpriteSheet, bAttackArea, Resources.BoomerangProj, Color.SandyBrown,
                0f, Vector2.Zero, SpriteEffects.None, 0.16f);
            sb.DrawString(Resources.MediumFont, "B", bLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.15f);
            //"A" attack + outline
            sb.Draw(Resources.ScreenCover, aOutline, null, Color.Blue,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            sb.Draw(Resources.ScreenCover, aInline, null, Color.Black,
                0f, Vector2.Zero, SpriteEffects.None, 0.17f);
            sb.Draw(Resources.WeaponsAndProjSpriteSheet, aAttackArea, Resources.WoodenSword, Color.SandyBrown,
                0f, Vector2.Zero, SpriteEffects.None, 0.16f);
            sb.DrawString(Resources.MediumFont, "A", aLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.15f);
            //Life
            sb.DrawString(Resources.MediumFont, "- LIFE: -", lifeLOC, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.18f);
            int heartXOffset = 556;
            for (int i = 0; i < numHearts; i++)
            {
                Rectangle LIFEArea = new Rectangle((int)CameraPosition.X + heartXOffset, (int)CameraPosition.Y + 60, Utils.GameWidth / 33, (int)(8 * Utils.GameScale));
                sb.Draw(Resources.ItemsSpriteSheet, LIFEArea, Resources.Heart, Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                heartXOffset += 25;
            }
        }

        public void Update()
        {
            HUDMap.Update();
            numGems = Player.Inventory.GetAmount(Types.Item.RUPEE);
            numKeys = Player.Inventory.GetAmount(Types.Item.KEY);
            numBombs = Player.Inventory.GetAmount(Types.Item.BOMB);
            numHearts = Player.Health;
        }
    }
}
