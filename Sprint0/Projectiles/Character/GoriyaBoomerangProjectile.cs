using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Character
{
    public class GoriyaBoomerangProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(5, 5);
        private bool IsReturning;

        public GoriyaBoomerangProjectile(Vector2 position, Types.Direction direction, ICollidable goriya) : 
            base(position, MovementSpeed, direction, goriya)
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

            Vector2 EndPos = Utils.CenterRectangles(User.GetHitbox(), GetHitbox());

            if (FramesPassed < (FramesAlive / 2))
            {
                Position += Velocity;
            }
            else if(FramesPassed >= FramesAlive / 2)
            {
                Position += (EndPos - Position) / (FramesAlive - FramesPassed);
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
