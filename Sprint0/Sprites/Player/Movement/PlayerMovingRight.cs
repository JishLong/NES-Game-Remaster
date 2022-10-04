using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingRight : AnimatedSprite
    {
        // Singleton instance
        private static PlayerMovingRight instance;

        public static PlayerMovingRight GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerMovingRight();
            }
            return instance;
        }

        private PlayerMovingRight() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkRight;
    }
}
