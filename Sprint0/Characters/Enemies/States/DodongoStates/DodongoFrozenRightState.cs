using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Characters.Enemies;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoFrozenRightState : AbstractCharacterState
    {
        private Dodongo Dodongo;
        private Types.Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;
        public DodongoFrozenRightState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoRightSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Dodongo.State = new DodongoMovingRightState(Dodongo);
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

            if ((FrozenTimer - FrozenDelay) > 0)
            {
                ChangeDirection();
            }
            Sprite.Update();
        }
    }
}

