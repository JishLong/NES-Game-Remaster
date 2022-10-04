using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Npcs
{
    public class OldManSprite : AnimatedSprite
    {
        public OldManSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.OldMan;

    }
}
