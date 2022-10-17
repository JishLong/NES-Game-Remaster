using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class PlayerBoomerangSprite : AnimatedSprite
    {
        public PlayerBoomerangSprite() : base(3, 12)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.BoomerangProj;
    }
}
