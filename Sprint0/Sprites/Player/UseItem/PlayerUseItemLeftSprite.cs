using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.UseItem
{
    public class PlayerUseItemLeftSprite : AbstractStillSprite
    {
        public PlayerUseItemLeftSprite()
        {
            xOffsetPixels = -12;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFrame() => Resources.LinkSwordSideways;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            DrawFlippedHorz(spriteBatch, position, color, layer);
        }
    }
}
