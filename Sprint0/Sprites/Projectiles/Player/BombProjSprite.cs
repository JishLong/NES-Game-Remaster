using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BombProjSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFrame() => Resources.BombProj;
    }
}
