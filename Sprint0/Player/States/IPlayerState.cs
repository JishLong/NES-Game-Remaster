using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Player.State
{
    public interface IPlayerState
    {
        public Player Player { get; }
        public int DamageFrameCounter { get; set; }

        public void ChangeDirection(Types.Direction direction);

        public void StopAction();

        public void DoPrimaryAttack();

        public void DoSecondaryAttack();

        public void TakeDamage();

        public Rectangle GetHitbox();

        public void Draw(SpriteBatch sb, Vector2 position);

        public void Update();
    }
}
