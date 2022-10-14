using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class FlameProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(5, 5);

        private int StillFrames;

        public FlameProjectile(Vector2 position, Types.Direction direction) : 
            base(position, MovementSpeed * Utils.DirectionToVector(direction))
        {
            FramesAlive = 60;
            FramesPassed = 0;
            StillFrames = 30;

            Sprite = new FlameProjSprite();
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if (FramesPassed < FramesAlive - StillFrames + 1)
            {
                Position += Velocity;
            }
        }
    }
}
