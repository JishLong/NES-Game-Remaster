using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackLeft : AnimatedSprite
    {
        // singleton instance
        private static PlayerSwordAttackLeft instance;

        public static PlayerSwordAttackLeft GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackLeft();
            }
            return instance;
        }

        private PlayerSwordAttackLeft() : base(4, 8)
        {
            xOffset = -0.5f;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordLeft;
    }
}
