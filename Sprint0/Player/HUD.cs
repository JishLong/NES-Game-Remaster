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

        public HUD() 
        {
        }

        public void Draw(SpriteBatch sb) 
        {
            Rectangle Area = new Rectangle((int)Camera.GetOffset().X, (int)Camera.GetOffset().Y, Utils.GameWidth, (int)(44 * Utils.GameScale));
            sb.Draw(Resources.ScreenCover, Area, null, Color.Yellow,
                0f, Vector2.Zero, SpriteEffects.None, 0.2f);
        }
        
        public void Update() 
        {

        }
    }
}
