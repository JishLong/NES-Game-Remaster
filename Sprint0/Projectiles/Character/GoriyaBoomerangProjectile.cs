using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Character;

namespace Sprint0.Projectiles.Character
{
    public class GoriyaBoomerangProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(5, 5);

        public GoriyaBoomerangProjectile(Vector2 position, Types.Direction direction) : 
            base(position, MovementSpeed, direction)
        {
            Sprite = new GoriyaBoomerangSprite();
            FramesAlive = 300;       
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if(FramesPassed < (FramesAlive / 2))
            {
                Position += Velocity;
            }
            else if(FramesPassed >= FramesAlive / 2)
            {
                Position -= Velocity;
            }
        }
    }
}
