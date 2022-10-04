using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class SkeletonSprite : AnimatedSprite
    {
        public SkeletonSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Skeleton;
    }
}
