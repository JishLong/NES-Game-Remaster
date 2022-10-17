using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BlueArrowProjSprite : StillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFrame() => Resources.BlueArrowProj;
    }
}
