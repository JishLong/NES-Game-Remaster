using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Character_Projectiles
{
    public class BossProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(3, 3);

        public BossProjectile(Vector2 position, Types.Direction direction) : base(position, MovementSpeed, direction)
        {
            Sprite = new BossProjSprite();
            FramesAlive = 180;
        }
    }
}
