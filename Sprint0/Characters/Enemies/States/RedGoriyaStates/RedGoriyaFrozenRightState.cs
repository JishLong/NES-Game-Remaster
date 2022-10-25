using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaFrozenRightState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for 5 seconds.

        public RedGoriyaFrozenRightState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaRightSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingRightState(Goriya);
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
