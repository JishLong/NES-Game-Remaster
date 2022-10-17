using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Player.State
{
    public interface IPlayerState
    {
        public Player Player { get; }

        // When the player takes damage, this is used to determine when the player should no longer appear damaged
        public int DamageFrameCounter { get; set; }

        public void Draw(SpriteBatch sb, Vector2 position);

        public void Update();

        public void ChangeDirection(Types.Direction direction);        

        public void DoPrimaryAttack();

        public void DoSecondaryAttack();

        public void StopAction();

        public void TakeDamage();

        public Rectangle GetHitbox();       
    }
}
