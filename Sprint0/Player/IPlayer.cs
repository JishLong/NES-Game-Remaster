using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Items;

namespace Sprint0.Player
{
    public interface IPlayer : ICollidable
    {
        Vector2 Position { get; set; }
        Types.Direction FacingDirection { get; set; }
        int Health { get; }
        bool IsStationary { get; set; }
        Types.Projectile SecondaryWeapon { get; set; } 

        HUD HUD { get; }

        Inventory Inventory { get; }

        void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch spriteBatch);

        void HoldItem(IItem item);

        void Move(Types.Direction direction);

        void StopAction();

        void Update();
    }
}
