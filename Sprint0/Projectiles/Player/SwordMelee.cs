using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordMelee : AbstractProjectile
    {
        public SwordMelee(Vector2 position, Types.Direction direction) :
            base(new SwordMeleeSprite(direction), null, position, Vector2.Zero, Types.Direction.NO_DIRECTION)
        {
            MaxFramesAlive = 20;
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
