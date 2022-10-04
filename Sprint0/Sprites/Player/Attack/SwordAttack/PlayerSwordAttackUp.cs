using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackUp : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackUp instance;

        public static PlayerSwordAttackUp GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackUp();
            }
            return instance;
        }

        private PlayerSwordAttackUp() : base(4, 8)
        {
            yOffset = -0.5f;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordUp;
    }
}
