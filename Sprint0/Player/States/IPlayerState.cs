using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.GameModes;
using Sprint0.Items;

namespace Sprint0.Player.States
{
    public interface IPlayerState
    {
        void Capture(ICommand goToBeginningCommand);

        void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game, Types.Direction direction);

        void Move(Types.Direction direction);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch sb, Vector2 position);

        Rectangle GetHitbox();

        void HoldItem(IItem item);

        void StopAction();

        void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode);

        void Update();
    }
}
