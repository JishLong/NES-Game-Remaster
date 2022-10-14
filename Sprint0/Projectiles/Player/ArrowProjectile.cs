using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);

        private float Rotation;
        private float ExplosionFrames;

        public ArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed * Utils.DirectionToVector(direction))
        {
            FramesAlive = 30;
            FramesPassed = 0;
            ExplosionFrames = 10;

            Sprite = new ArrowProjSprite();

            switch (direction)
            {
                case Types.Direction.LEFT:
                    Rotation = MathHelper.ToRadians(270);
                    break;
                case Types.Direction.RIGHT:
                    Rotation = MathHelper.ToRadians(90);
                    break;
                case Types.Direction.UP:
                    Rotation = 0;
                    break;
                case Types.Direction.DOWN:
                    Rotation = MathHelper.ToRadians(180);
                    break;
                default:
                    break;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, Rotation);
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if (FramesPassed == FramesAlive - ExplosionFrames)
            {
                Sprite = new ArrowExplosionProjSprite();
                Rotation = 0;
            }
            if (FramesPassed < FramesAlive - ExplosionFrames)
            {
                Position += Velocity;
            }
        }

        public override Rectangle GetHitbox()
        {
            // Incorrect for now - also needs to rotate
            Rectangle retVal = (FramesPassed < FramesAlive - ExplosionFrames) ? Sprite.GetDrawbox(Position) : Rectangle.Empty;
            return retVal;
        }
    }
}
