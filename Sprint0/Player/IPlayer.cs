using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Commands;
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
        Types.Projectile SecondaryWeapon { get; set; }

        string inputId { get; set; }

        PlayerHUD HUD { get; }

        Inventory.Inventory Inventory { get; }

        void Capture(ICommand goToBeginningCommand);

        void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game, Types.Direction direction = Types.Direction.NO_DIRECTION);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch spriteBatch);

        void HoldItem(IItem item);

        void Move(Types.Direction direction);

        void StopAction();

        void Update();
    }
}
