using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandMovingUpState : AbstractEnemyState
    {
        private Hand Hand;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        private bool ClockWise;
        public HandMovingUpState(Hand hand, bool clockWise)
        {
            Hand = hand;
            StateDirection = Direction.Up;
            DirectionVector = ToVector(StateDirection);
            ClockWise = clockWise;
            Sprite = new HandSprite();
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            if (ClockWise)
            {
                Hand.State = new HandMovingRightState(Hand, ClockWise);
            }
            else
            {
                Hand.State = new HandMovingLeftState(Hand, ClockWise);
            }
        } 
        public override void Freeze()
        {
            Hand.State = new HandFrozenState(Hand, StateDirection, ClockWise);
        }

        public override void Move()
        {
            Hand.Position += DirectionVector * Hand.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
