using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Player
{
    public interface IPlayer : ICollidable
    {
        public Types.PlayerWeapon SecondaryWeapon { get; set; }
        public bool IsPrimaryAttacking { get; set; }
        public bool IsStationary { get; set; }
        public Types.Direction FacingDirection { get; set; }

        public Inventory Inventory { get; }
        public float Damage { get; }

        public void Update();

        public void Draw(SpriteBatch spriteBatch);

        public void ChangeDirection(Types.Direction direction);

        public void DoPrimaryAttack();

        public void DoSecondaryAttack();

        public void StopAction();

        public void TakeDamage();

        public void location(Vector2 newLoc);

        public Vector2 GetPosition();
    }
}
