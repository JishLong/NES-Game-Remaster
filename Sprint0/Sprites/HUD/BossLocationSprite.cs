using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Doors.UnlockdDoorSprites
{
    public class BossLocationSprite: AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.PlayerLocationSheet;

        protected override Rectangle GetFrame() => Resources.PlayerLocation;

        private float ColorOpacity = 0.0f;

        private int FadeFrames = 20;
        private bool FadingIn = true;
        private int Frames = 0;


        public override void Update()
        {
            Frames++;
            if(Frames > FadeFrames)
            {
                Frames = 0;
                FadingIn = !FadingIn;
            }

            if (FadingIn)
            {
                ColorOpacity += 1f / FadeFrames;
            } else
            {
                ColorOpacity -= 1f / FadeFrames;
            }
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetFrame(),
                Color.Red * ColorOpacity, 0, Vector2.Zero, SpriteEffects.None, layer);
        }
    }
}
