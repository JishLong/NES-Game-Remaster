using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackRight : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackRight instance;

        public static PlayerSwordAttackRight GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackRight();
            }
            return instance;
        }

        private PlayerSwordAttackRight() : base(4, 8)
        {
            
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordRight;
    }
}
