using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackRight : AbstractAnimatedSprite
    {
        public PlayerSwordAttackRight() : base(4, 4)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordSideways;
    }
}
