using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingLeft : AnimatedSprite
    {
        // singleton instance
        private static PlayerMovingLeft instance;

        public static PlayerMovingLeft GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerMovingLeft();
            }
            return instance;
        }

        private PlayerMovingLeft() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkLeft;
    }
}
