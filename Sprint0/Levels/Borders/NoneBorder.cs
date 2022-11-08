using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.Blocks;
using static Sprint0.Utils;

namespace Sprint0.Levels.Borders
{
    public class NoneBorder: IBorder
    {
        private Vector2 DefaultPosition;
        private float DefaultLayerDepth = 1;
        public NoneBorder()
        {
            DefaultPosition = new Vector2(0, 0);
        }

        public void Update()
        {
            // Nothing to update.
        }

        public void Draw(SpriteBatch sb)
        {
            // Nothing to draw.
        }
    }
}
