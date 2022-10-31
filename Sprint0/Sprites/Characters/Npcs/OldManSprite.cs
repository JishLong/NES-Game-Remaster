using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Npcs
{
    public class OldManSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFrame() => Resources.OldMan;
    }
}
