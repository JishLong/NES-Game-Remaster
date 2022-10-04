using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackDown : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackDown instance;

        public static PlayerSwordAttackDown GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackDown();
            }
            return instance;
        }

        private PlayerSwordAttackDown() : base(4, 8)
        {
            
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordDown;
    }
}
