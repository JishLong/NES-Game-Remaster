using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordMelee : AbstractProjectile
    {
        public SwordMelee(ICollidable user, Types.Direction direction) :
            base(new SwordMeleeSprite(direction), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = 20;
            Damage = 1;
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
