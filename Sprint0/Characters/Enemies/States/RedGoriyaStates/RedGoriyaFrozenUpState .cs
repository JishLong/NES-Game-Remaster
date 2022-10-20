using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaFrozenUpState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for 5 seconds.

        public RedGoriyaFrozenUpState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaUpSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingUpState(Goriya);
        }
        public override void Freeze()
        {
            // Already frozen.
        }
        public override void ChangeDirection()
        {
            // Do nothing. Cant change direction while frozen.
        }
        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            FrozenTimer += elapsedTime;

            if((FrozenTimer - FrozenDelay) > 0)
            {
                Move();
            }
            Sprite.Update();
        }
    }
}
