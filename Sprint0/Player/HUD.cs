using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Player
{
    public class HUD
    {
        //private static Rectangle HUDArea = new Rectangle((int)Camera.GetOffset().X, (int)Camera.GetOffset().Y, Utils.GameWidth, (int)(44 * Utils.GameScale));

        //mini map, gems, keys, bombs, "A" key attack, "B" key attack, Life
        private static Rectangle MAPArea = new Rectangle((int)Camera.GetOffset().X + 30, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 3, (int)(30 * Utils.GameScale));
        private static Rectangle gemsAREA = new Rectangle((int)Camera.GetOffset().X + 305, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 10, (int)(10 * Utils.GameScale));
        private static Rectangle keysAREA = new Rectangle((int)Camera.GetOffset().X + 305, (int)Camera.GetOffset().Y + 48, Utils.GameWidth / 10, (int)(10 * Utils.GameScale));
        private static Rectangle bombAREA = new Rectangle((int)Camera.GetOffset().X + 305, (int)Camera.GetOffset().Y + 82, Utils.GameWidth / 10, (int)(10 * Utils.GameScale));
        private static Rectangle bAttackArea = new Rectangle((int)Camera.GetOffset().X + 400, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
        private static Rectangle aAttackArea = new Rectangle((int)Camera.GetOffset().X + 475, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
        private static Rectangle LIFEArea = new Rectangle((int)Camera.GetOffset().X + 550, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 4, (int)(30 * Utils.GameScale));

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
            sb.Draw(Resources.ScreenCover, gemsAREA, null, Color.YellowGreen,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            //keys
            sb.Draw(Resources.ScreenCover, keysAREA, null, Color.Wheat,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            //bombs
            sb.Draw(Resources.ScreenCover, bombAREA, null, Color.SteelBlue,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            //"B" attack
            sb.Draw(Resources.ScreenCover, bAttackArea, null, Color.Turquoise,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            //"A" attack
            sb.Draw(Resources.ScreenCover, aAttackArea, null, Color.Violet,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            //Life
            sb.Draw(Resources.ScreenCover, LIFEArea, null, Color.Red,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
        }
        
        public void Update() 
        {

        }
    }
}
