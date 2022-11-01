using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackUp : AbstractAnimatedSprite
    {
        public PlayerSwordAttackUp() : base(4, 4)
        {
            yOffsetPixels = -12;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordUp;
    }
}
