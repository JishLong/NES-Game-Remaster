using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using Sprint0.Items;

namespace Sprint0.Player
{
    public interface IPlayer : ICollidable
    {
        public Vector2 Position { get; set; }
        Types.Projectile SecondaryWeapon { get; set; }
        Types.Direction FacingDirection { get; set; }
        bool IsStationary { get; set; }

        void ChangeDirection(Types.Direction direction);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch spriteBatch);

        void PickUpItem(IItem item);

        void StopAction();

        void TakeDamage(int damage, Game1 game);

        void Update();
    }
}
