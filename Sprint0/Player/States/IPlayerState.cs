using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Items;

namespace Sprint0.Player.State
{
    public interface IPlayerState
    {
        void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game);

        void Move(Types.Direction direction);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch sb, Vector2 position);

        Rectangle GetHitbox();

        void HoldItem(IItem item);

        void StopAction();

        void Update();
    }
}
