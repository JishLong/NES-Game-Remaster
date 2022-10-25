using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Character_Projectiles
{
    public class BossProjectile : AbstractProjectile
    {
        public BossProjectile(Vector2 position, Types.Direction direction) : 
            base(new BossProjSprite(), null, position, new Vector2(3, 3), direction)
        {
            MaxFramesAlive = 180;
        }
    }
}
