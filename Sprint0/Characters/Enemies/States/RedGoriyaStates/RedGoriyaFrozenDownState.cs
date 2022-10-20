using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaFrozenDownState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for 5 seconds.

        public RedGoriyaFrozenDownState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaDownSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Goriya.State = new RedGoriyaMovingDownState(Goriya);
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
