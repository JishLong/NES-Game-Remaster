using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Player
{
    public class HUD
    {
        public HUD() 
        { 

        }

        public void Draw(SpriteBatch sb) 
        {
            Rectangle HUDArea = new Rectangle((int)Camera.GetOffset().X, (int)Camera.GetOffset().Y, Utils.GameWidth, (int)(44 * Utils.GameScale));

            //mini map, gems, keys, bombs, "A" key attack, "B" key attack, Life
            Rectangle MAPArea = new Rectangle((int)Camera.GetOffset().X + 30, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 3, (int)(30 * Utils.GameScale));
            Rectangle gemsAREA = new Rectangle((int)Camera.GetOffset().X + 305, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 10, (int)(10 * Utils.GameScale));
            Rectangle keysAREA = new Rectangle((int)Camera.GetOffset().X + 305, (int)Camera.GetOffset().Y + 48, Utils.GameWidth / 10, (int)(10 * Utils.GameScale));
            Rectangle bombAREA = new Rectangle((int)Camera.GetOffset().X + 305, (int)Camera.GetOffset().Y + 82, Utils.GameWidth / 10, (int)(10 * Utils.GameScale));
            Rectangle bAttackArea = new Rectangle((int)Camera.GetOffset().X + 400, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
            Rectangle aAttackArea = new Rectangle((int)Camera.GetOffset().X + 475, (int)Camera.GetOffset().Y + 15, Utils.GameWidth / 12, (int)(30 * Utils.GameScale));
            Rectangle LIFEArea = new Rectangle((int)Camera.GetOffset().X + 550, (int)Camera.GetOffset().Y + 20, Utils.GameWidth / 4, (int)(30 * Utils.GameScale));

            sb.Draw(Resources.ScreenCover, HUDArea, null, Color.Black,
              0f, Vector2.Zero, SpriteEffects.None, 0.19f);

            //mini map
            sb.Draw(Resources.ScreenCover, MAPArea, null, Color.White,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            //gems
            sb.Draw(Resources.ItemsSpriteSheet, gemsAREA, Resources.Rupee, Color.YellowGreen,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            //keys
            sb.Draw(Resources.ItemsSpriteSheet, keysAREA, Resources.Key, Color.Wheat,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            //bombs
            sb.Draw(Resources.ItemsSpriteSheet, bombAREA, Resources.Bomb, Color.SteelBlue,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            //"B" attack
            sb.Draw(Resources.ScreenCover, bAttackArea, null, Color.Turquoise,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            //"A" attack
            sb.Draw(Resources.ScreenCover, aAttackArea, null, Color.Violet,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            //Life
            sb.Draw(Resources.ItemsSpriteSheet, LIFEArea, Resources.Heart, Color.Red,
                0f, Vector2.Zero, SpriteEffects.None, 0.18f);
        }
        
        public void Update() 
        {

        }
    }
}
