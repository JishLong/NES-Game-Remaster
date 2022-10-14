using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);

        private readonly float rotation;

        public ArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed * Utils.DirectionToVector(direction))
        {
            FramesAlive = 60;
            FramesPassed = 0;

            Sprite = new ArrowProjectileSprite();

            switch (direction)
            {
                case Types.Direction.LEFT:
                    rotation = MathHelper.ToRadians(270);
                    break;
                case Types.Direction.RIGHT:
                    rotation = MathHelper.ToRadians(90);
                    break;
                case Types.Direction.UP:
                    rotation = 0;
                    break;
                case Types.Direction.DOWN:
                    rotation = MathHelper.ToRadians(180);
                    break;
                default:
                    break;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position, Color.White, rotation);
        }
    }
}
