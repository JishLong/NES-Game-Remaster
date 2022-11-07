using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Items;

namespace Sprint0.Player.State
{
    public interface IPlayerState
    {
        Player Player { get; }

        void ChangeDirection(Types.Direction direction);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch sb, Vector2 position);

        void PickUpItem(IItem item);

        Rectangle GetHitbox();

        void StopAction();

        void TakeDamage(int damage, Game1 game);     

        void Update();
    }
}
