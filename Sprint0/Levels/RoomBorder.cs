using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Levels
{
    public class RoomBorder
    {
        private ISprite Sprite;
        private Vector2 DefaultPosition;
        public RoomBorder()
        {
            Sprite = new Level1BorderSprite();
            DefaultPosition = new Vector2(0,0);
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, DefaultPosition);
        }
    }
}
