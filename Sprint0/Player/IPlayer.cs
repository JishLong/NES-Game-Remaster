using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Player
{
    public interface IPlayer : ICollidable
    {
        public Vector2 Position { get; set; }
        Types.PlayerWeapon SecondaryWeapon { get; set; }
        Types.Direction FacingDirection { get; set; }
        bool IsStationary { get; set; }

        void ChangeDirection(Types.Direction direction);

        void DoPrimaryAttack();

        void DoSecondaryAttack();

        void Draw(SpriteBatch spriteBatch);

        void StopAction();

        void TakeDamage(int damage);

        void Update();
    }
}
