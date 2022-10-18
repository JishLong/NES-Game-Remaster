using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(15, 15);

        private float Rotation;
        private int ExplosionFrames;

        public BlueArrowProjectile(Vector2 position, Types.Direction direction) :
            base(position, MovementSpeed * Utils.DirectionToVector(direction))
        {
            FramesAlive = 60;
            FramesPassed = 0;
            ExplosionFrames = 10;

            Sprite = new BlueArrowProjSprite();

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

            if (FramesPassed == FramesAlive - ExplosionFrames + 1)
            {
                Sprite = new ArrowExplosionProjSprite();
                Rotation = 0;
            }
            if (FramesPassed < FramesAlive - ExplosionFrames + 1)
            {
                Position += Velocity;
            }
        }
        public override Rectangle GetHitbox()
        {
            // Incorrect for now - also needs to rotate
            Rectangle retVal = (FramesPassed < FramesAlive - ExplosionFrames + 1) ? Sprite.GetDrawbox(Position) : Rectangle.Empty;
            return retVal;
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
