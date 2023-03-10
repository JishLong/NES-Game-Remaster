using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.Blocks;
using Sprint0.Sprites.Borders;
using static Sprint0.Utils;

namespace Sprint0.Levels.Borders
{
    public class BlueRoomBorder : IBorder
    {
        private ISprite Sprite;
        private Vector2 DefaultPosition;

        public BlueRoomBorder()
        {
            Sprite = new BlueBorderSprite();
            DefaultPosition = new Vector2(0, 0);
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, LinkToCamera(DefaultPosition), Color.White, WallLayerDepth);
        }
    }
}
