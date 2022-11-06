using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Character_Projectiles
{
    public class BossProjectile : AbstractProjectile
    {
        public BossProjectile(ICollidable user, Types.Direction direction) : 
            base(new BossProjSprite(), user, direction, new Vector2(2, 2))
        {
            MaxFramesAlive = 180;
            Damage = 1;
        }
    }
}
