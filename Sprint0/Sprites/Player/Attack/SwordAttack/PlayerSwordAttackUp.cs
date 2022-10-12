using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    // NOTE: this class is using new draw logic that is not yet implemented in most other sprite classes
    public class PlayerSwordAttackUp : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackUp instance;

        public static PlayerSwordAttackUp GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackUp();
            }
            return instance;
        }

        private PlayerSwordAttackUp() : base(4, 8)
        {
            
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordUp;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle frame = GetFirstFrame();
            if (CurrentFrame != 0)
            {
                frame = new Rectangle(frame.X + CurrentFrame * frame.Width, frame.Y, frame.Width, frame.Height);
            }

            spriteBatch.Draw(GetSpriteSheet(), new Rectangle((int)(position.X),
                (int)(position.Y - 12 * SizeScale),
                (int)(frame.Width * SizeScale), (int)(frame.Height * SizeScale)),
                frame, Color.White);
        }
    }
}
