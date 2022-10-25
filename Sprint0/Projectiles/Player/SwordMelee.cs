using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordMelee : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(0, 0);

        public SwordMelee(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed, direction, null)
        {
            Sprite = new SwordMeleeSprite(direction);
            FramesAlive = 32;
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
