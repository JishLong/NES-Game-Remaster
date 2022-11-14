using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites
{
    public abstract class AbstractStillSprite : ISprite
    {
        /* [xOffsetPixels]: a number of pixels the sprite's x-coordinate is offset by (scales automatically with GameScale)
         * [yOffset]: a number of pixels the sprite's y-coordinate is offset by (scales automatically ywith GameScale)
         */
        protected int xOffsetPixels, yOffsetPixels;

        protected AbstractStillSprite()
        {
            xOffsetPixels = 0;
            yOffsetPixels = 0;
        }

        protected abstract Rectangle GetFrame();

        protected abstract Texture2D GetSpriteSheet();

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetInstance().Position), GetFrame(),
                color, 0, Vector2.Zero, SpriteEffects.None, layer);
        }

        protected void DrawFlippedHorz(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetInstance().Position), GetFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, layer);
        }

        protected void DrawFlippedVert(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetInstance().Position), GetFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipVertically, layer);
        }

        public int GetAnimationTime()
        {
            return 0;
        }

        public Rectangle GetDrawbox(Vector2 position)
        {
            Rectangle frame = GetFrame();

            return new Rectangle((int)(position.X + (xOffsetPixels * Utils.GameScale)),
                (int)(position.Y + (yOffsetPixels * Utils.GameScale)),
                (int)(frame.Width * Utils.GameScale),
                (int)(frame.Height * Utils.GameScale));
        }

        public void Update()
        {
            // Nothing here!
        }  
    }
}
