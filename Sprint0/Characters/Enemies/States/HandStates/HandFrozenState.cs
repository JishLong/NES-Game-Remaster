using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandFrozenState: AbstractEnemyState
    {
        private Hand Hand;
        private Direction ResumeMovementDirection;
        private bool ClockWise;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public HandFrozenState(Hand hand, Direction direction, bool clockWise)
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
                case Direction.Left:
                    Hand.State = new HandMovingLeftState(Hand, ClockWise);
                    break;
                case Direction.Right:
                    Hand.State = new HandMovingRightState(Hand, ClockWise);
                    break;
                case Direction.Down:
                    Hand.State = new HandMovingDownState(Hand, ClockWise);
                    break;
                case Direction.Up:
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
