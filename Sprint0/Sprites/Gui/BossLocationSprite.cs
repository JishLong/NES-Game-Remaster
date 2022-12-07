using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Gui
{
    public class BossLocationSprite: AbstractSprite
    {
        private readonly int FadeFrames = 20;

        private int FramesPassed = 0;
        private float ColorOpacity = 0.0f;
        private bool FadingIn = true;

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().GuiElementsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().HudMapPlayer;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.HudMapPlayer;

        public override void Update()
        {
            FramesPassed++;
            if(FramesPassed > FadeFrames)
            {
                FramesPassed = 0;
                FadingIn = !FadingIn;
            }

            if (FadingIn) ColorOpacity += 1f / FadeFrames;
            else ColorOpacity -= 1f / FadeFrames;   
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {    
            spriteBatch.Draw(GetSpriteSheet(), GetHitbox(position), GetFirstFrame(),
                Color.Red * ColorOpacity, 0, Vector2.Zero, SpriteEffects.None, layer);
        }
    }
}
