using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Character
{
    public class BladeTrapTrigger : AbstractProjectile
    {
        private Vector2 Dims;
        private readonly Types.Direction Direction;

        public BladeTrapTrigger(ICollidable user, Types.Direction direction) :
            base(new SwordMeleeSprite(direction), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = 1;
            Damage = 0;
            Direction = direction;

            // We want this projectile to essentially stretch in one long line so the player can be detected even from far away
            switch (direction) 
            {
                case Types.Direction.LEFT:
                    Dims = new Vector2(Utils.GameWidth, user.GetHitbox().Height);
                    Position = new Vector2(user.GetHitbox().X - Dims.X, user.GetHitbox().Y);
                    break;
                case Types.Direction.RIGHT:
                    Dims = new Vector2(Utils.GameWidth, user.GetHitbox().Height);
                    Position = new Vector2(user.GetHitbox().Right, user.GetHitbox().Y);
                    break;
                case Types.Direction.UP:
                    Dims = new Vector2(user.GetHitbox().Width, Utils.GameHeight);
                    Position = new Vector2(user.GetHitbox().X, user.GetHitbox().Y - Dims.Y);
                    break;
                case Types.Direction.DOWN:
                    Dims = new Vector2(user.GetHitbox().Width, Utils.GameHeight);
                    Position = new Vector2(user.GetHitbox().X, user.GetHitbox().Bottom);
                    break;
                default:
                    break;
            }
        }

        public override void DeathAction()
        {
            // Nothing here!
        }

        public override Rectangle GetHitbox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Dims.X, (int)Dims.Y);
        }

        public override void Draw(SpriteBatch sb)
        {
            // Invisible!
        }

        public void TriggerBladeTrap() 
        {
            (User as BladeTrap).Attack(Direction);
        }
    }
}
