using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Movement
{
    public class PlayerMovingUp : AnimatedSprite
    {
        // singleton instance
        private static PlayerMovingUp instance;

        public static PlayerMovingUp GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerMovingUp();
            }
            return instance;
        }

        private PlayerMovingUp() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkUp;
    }
}
