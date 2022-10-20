using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    // NOTE: this class is using new draw logic that is not yet implemented in most other sprite classes
    public class PlayerSwordAttackLeft : AnimatedSprite
    {
        public PlayerSwordAttackLeft() : base(4, 8)
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
