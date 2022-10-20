using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandMovingDownState : AbstractCharacterState
    {
        private Hand Hand;
        private Types.Direction StateDirection;
        private Vector2 DirectionVector;
        private bool ClockWise;
        public HandMovingDownState(Hand hand, bool clockWise)
        {
            Hand = hand;
            StateDirection = Types.Direction.DOWN;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new HandSprite();
            ClockWise = clockWise;
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            if (ClockWise)
            {
                Hand.State = new HandMovingLeftState(Hand, ClockWise);
            }
            else
            {
                Hand.State = new HandMovingRightState(Hand, ClockWise);
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
