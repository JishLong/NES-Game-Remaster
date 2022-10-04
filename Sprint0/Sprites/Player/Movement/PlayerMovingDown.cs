using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingDown : AnimatedSprite
    {
        // Singleton instance
        private static PlayerMovingDown instance;

        public static PlayerMovingDown GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerMovingDown();
            }
            return instance;
        }

        private PlayerMovingDown() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkDown;
    }
}
