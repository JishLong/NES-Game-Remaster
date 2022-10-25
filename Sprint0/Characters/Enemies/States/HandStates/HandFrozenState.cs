using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandFrozenState: AbstractCharacterState
    {
        private readonly Hand Hand;
        private readonly Types.Direction ResumeMovementDirection;
        private readonly bool ClockWise;
        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public HandFrozenState(Hand hand, Types.Direction direction, bool clockWise)
        {
            Hand = hand;
            ResumeMovementDirection = direction;
            Sprite = new HandSprite();
            ClockWise = clockWise;
        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            switch (ResumeMovementDirection)
            {
                case Types.Direction.LEFT:
                    Hand.State = new HandMovingLeftState(Hand, ClockWise);
                    break;
                case Types.Direction.RIGHT:
                    Hand.State = new HandMovingRightState(Hand, ClockWise);
                    break;
                case Types.Direction.DOWN:
                    Hand.State = new HandMovingDownState(Hand, ClockWise);
                    break;
                case Types.Direction.UP:
                    Hand.State = new HandMovingUpState(Hand, ClockWise);
                    break;
            }
        }

        public override void Freeze()
        {
            // Already frozen.
        }

        public override void Move()
        {
            // Cannot move while frozen
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            FrozenTimer += elapsedTime;

            if((FrozenTimer - FrozenDelay) > 0)
            {
                ChangeDirection();
            }
            Sprite.Update();
        }
    }
}
