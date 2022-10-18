using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player
{
    public class PlayerBoomerangProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(5, 5);

        public PlayerBoomerangProjectile(Vector2 position, Types.Direction direction) : 
            base(position, MovementSpeed * Utils.DirectionToVector(direction))
        {
            FramesAlive = 75;
            FramesPassed = 0;
            Sprite = new PlayerBoomerangSprite();
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if (FramesPassed < (FramesAlive / 2))
            {
                Position += Velocity;
            }
            else if (FramesPassed >= FramesAlive / 2)
            {
                Position -= Velocity;
            }
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
