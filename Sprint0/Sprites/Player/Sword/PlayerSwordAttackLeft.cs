using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackLeft : AbstractAnimatedSprite
    {
        public PlayerSwordAttackLeft() : base(4, 4)
        {
            xOffsetPixels = -12;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordSideways;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            DrawFlippedHorz(spriteBatch, position, color);
        }
    }
}
