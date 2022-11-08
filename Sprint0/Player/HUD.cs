using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Player;

namespace Sprint0.Player
{
    public class HUD: Inventory
    {
        //private static Rectangle HUDArea = new Rectangle((int)Camera.GetOffset().X, (int)Camera.GetOffset().Y, Utils.GameWidth, (int)(44 * Utils.GameScale));

        //mini map, gems, keys, bombs, "A" key attack, "B" key attack, Life
        private static Rectangle MAPArea = new Rectangle((int)Camera.GetOffset().X + 30, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 3, (int)(30 * Utils.GameScale));

        private static Rectangle gemsAREA = new Rectangle((int)Camera.GetOffset().X + 300, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 28, (int)(10 * Utils.GameScale));
        private static Rectangle keysAREA = new Rectangle((int)Camera.GetOffset().X + 300, (int)Camera.GetOffset().Y + 48, Utils.GameWidth / 28, (int)(10 * Utils.GameScale));
        private static Rectangle bombAREA = new Rectangle((int)Camera.GetOffset().X + 297, (int)Camera.GetOffset().Y + 82, Utils.GameWidth / 28, (int)(10 * Utils.GameScale));

        private static Rectangle bAttackArea = new Rectangle((int)Camera.GetOffset().X + 400, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
        private static Rectangle aAttackArea = new Rectangle((int)Camera.GetOffset().X + 475, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));

        int numGems = 0;
        int numKeys = 0;
        int numBombs = 0;
        //int numHearts = Player.health;
        int numHearts = 6;

        public HUD() 
        { 
        }

        public void Draw(SpriteBatch sb) 
        {
            //sb.Draw(Resources.ScreenCover, HUDArea, null, Color.Black,
            //  0f, Vector2.Zero, SpriteEffects.None, 0.2f);

            //mini map
            sb.Draw(Resources.ScreenCover, MAPArea, null, Color.White,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);

            //gems
            //int numGems = GetAmount(Types.Item.RUPEE);
            sb.Draw(Resources.ItemsSpriteSheet, gemsAREA, Resources.Rupee, Color.GhostWhite,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            Vector2 gemLoc = new Vector2((int)Camera.GetOffset().X + 335, (int)Camera.GetOffset().Y + 10);
            sb.DrawString(Resources.MediumFont, "X" + numGems, gemLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

            //keys
            //int numKeys = GetAmount(Types.Item.KEY);
            sb.Draw(Resources.ItemsSpriteSheet, keysAREA, Resources.Key, Color.YellowGreen,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            Vector2 keyLoc = new Vector2((int)Camera.GetOffset().X + 335, (int)Camera.GetOffset().Y + 44);
            sb.DrawString(Resources.MediumFont, "X" + numKeys, keyLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

            //bombs
            //int numBombs = GetAmount(Types.Item.BOMB);
            sb.Draw(Resources.ItemsSpriteSheet, bombAREA, Resources.Bomb, Color.SteelBlue,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            Vector2 bombLoc = new Vector2((int)Camera.GetOffset().X + 335, (int)Camera.GetOffset().Y + 80);
            sb.DrawString(Resources.MediumFont, "X" + numBombs, bombLoc, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

            //"B" attack
            //set on boomerang sprite until current inventory is setup
            sb.Draw(Resources.WeaponsAndProjSpriteSheet, bAttackArea, Resources.BoomerangProj, Color.SandyBrown,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);

            //"A" attack
            sb.Draw(Resources.WeaponsAndProjSpriteSheet, aAttackArea, Resources.WoodenSword, Color.SandyBrown,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);

            //Life
            //int numHearts = 6 + GetAmount(Types.Item.HEART);
            Vector2 lifeLOC = new Vector2((int)Camera.GetOffset().X + 555, (int)Camera.GetOffset().Y + 15);
            sb.DrawString(Resources.MediumFont, "- LIFE: -", lifeLOC, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

            int heartXOffset = 556;
            int heartYOffset = 60;
            Boolean secondRow = false;

            //print out hearts on second row
            for (int i = 0; i < numHearts; i++)
            {
                if (numHearts > 7 && secondRow == false)
                {
                    heartYOffset += 37;
                    heartXOffset = 556;
                    secondRow = true;
                } else
                {
                    Rectangle LIFEArea = new Rectangle((int)Camera.GetOffset().X + heartXOffset, (int)Camera.GetOffset().Y + heartYOffset, Utils.GameWidth / 33, (int)(8 * Utils.GameScale));
                    sb.Draw(Resources.ItemsSpriteSheet, LIFEArea, Resources.Heart, Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                    heartXOffset += 25;
                }
            }
        }
        
        public void Update() 
        {
            numGems += GetAmount(Types.Item.RUPEE);
            numKeys += GetAmount(Types.Item.KEY);
            numBombs += GetAmount(Types.Item.BOMB);
            numHearts += GetAmount(Types.Item.HEART);
        }
    }
}
