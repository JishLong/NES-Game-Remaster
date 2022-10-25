using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Player.State
{
    public interface IPlayerState
    {
        Player Player { get; }

        void ChangeDirection(Types.Direction direction);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch sb, Vector2 position);

        Rectangle GetHitbox();

        void StopAction();

        void TakeDamage(int damage);     

        void Update();
    }
}
