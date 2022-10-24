using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player
{
    public class PlayerBoomerangProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(5, 5);

        public PlayerBoomerangProjectile(Vector2 position, Types.Direction direction, ICollidable player) : 
            base(position, MovementSpeed, direction, player)
        {
            Sprite = new PlayerBoomerangSprite();
            FramesAlive = 75;   
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            Vector2 EndPos = Utils.CenterRectangles(User.GetHitbox(), GetHitbox());

            if (FramesPassed < (FramesAlive / 2))
            {
                Position += Velocity;
            }
            else if (FramesPassed >= FramesAlive / 2)
            {
                Position += (EndPos - Position) / (FramesAlive - FramesPassed);
            }
        }

        public override bool FromPlayer()
        {
            return true;
        }

        public void ReturnBoomerang() 
        {
            FramesPassed = FramesAlive - FramesPassed;
        }
    }
}
