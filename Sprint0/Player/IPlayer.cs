using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Player
{
    public interface IPlayer : ICollidable
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch);

        public void ChangeDirection(Types.Direction direction);

        public void DoPrimaryAttack();

        public void DoSecondaryAttack();

        public void StopAction();

        public void TakeDamage();

        public void Reset();
    }
}
