using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    // NOTE: this class is using new draw logic that is not yet implemented in most other sprite classes
    public class PlayerSwordAttackLeft : AnimatedSprite
    {
        public PlayerSwordAttackLeft() : base(4, 8)
        {
            xOffsetPixels = -12;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordRight;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle frame = GetFirstFrame();
            if (CurrentFrame != 0)
            {
                frame = new Rectangle(frame.X + CurrentFrame * frame.Width, frame.Y, frame.Width, frame.Height);
            }

            Vector2 spritePos = new Vector2(position.X + (xOffsetPixels * SizeScale), position.Y);

            spriteBatch.Draw(GetSpriteSheet(), spritePos, frame, color, 0,
                Vector2.Zero, new Vector2(3, 3), SpriteEffects.FlipHorizontally, 0);
        }

        public override void Update()
        {
            Timer = (Timer + 1) % Speed;
            if (Timer == 0)
            {
                CurrentFrame++;
                if (CurrentFrame == NumFrames - 1)
                {
                    CurrentFrame = 0;
                }
            }
        }
    }
}
