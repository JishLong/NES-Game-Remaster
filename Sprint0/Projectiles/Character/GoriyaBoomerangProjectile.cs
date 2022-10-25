using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Character
{
    public class GoriyaBoomerangProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(5, 5);
        private bool IsReturning;

        public GoriyaBoomerangProjectile(Vector2 position, Types.Direction direction) : 
            base(position, MovementSpeed, direction, null)
        {
            Sprite = new GoriyaBoomerangSprite();
            FramesAlive = 300;
            IsReturning = false;
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;
            IsReturning = false;

            if(FramesPassed < (FramesAlive / 2))
            {
                Position += Velocity;
            }
            else if(FramesPassed >= FramesAlive / 2)
            {
                Position -= Velocity;
            }
        }

        public void ReturnBoomerang()
        {
            if (!IsReturning) 
            {
                FramesPassed = FramesAlive - FramesPassed;
                IsReturning = true;
            } 
        }
    }
}
