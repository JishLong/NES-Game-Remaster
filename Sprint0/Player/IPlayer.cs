using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Commands;
using Sprint0.GameModes;
using Sprint0.Items;
using Sprint0.Player.HUD;

namespace Sprint0.Player
{
    public interface IPlayer : ICollidable
    {
        Vector2 Position { get; set; }
        Types.Direction FacingDirection { get; set; }
        int Health { get; }
        int MaxHealth { get; }
        bool IsStationary { get; set; }
        bool GodmodeEnabled { get; set; }
        Types.Projectile SecondaryWeapon { get; set; }
        Types.GameMode GameMode { get; set; }

        string inputId { get; set; }

        PlayerHUD HUD { get; }

        Inventory.Inventory Inventory { get; }

        void Capture(ICommand goToBeginningCommand);

        void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game, 
            Types.Direction direction = Types.Direction.NO_DIRECTION, bool setOverride = false);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch spriteBatch);

        void HoldItem(IItem item);

        void Move(Types.Direction direction);

        void StopAction();

        void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode);

        void Update();
    }
}
