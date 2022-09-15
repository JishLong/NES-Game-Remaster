using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class TextSprite : ISprite
    {
        public void Update(int screenW, int screenH)
        {
            // Nothing needed here
        }

        public void Draw(SpriteBatch sb, int screenW, int screenH)
        {
            sb.DrawString(Resources.creditsFont, "Credits:", new Vector2(30, 30), Color.Black);
            sb.DrawString(Resources.creditsFont, "Program made by Josh Long", new Vector2(30, 64), Color.Black);
            sb.DrawString(Resources.creditsFont, "Sprites from https://www.mariouniverse.com", new Vector2(30, 98), Color.Black);
        }
    }
}
