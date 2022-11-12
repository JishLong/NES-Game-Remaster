using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.HandStates
{
    public class HandFrozenState: AbstractCharacterState
    {
        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;
        private readonly bool ClockWise;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public HandFrozenState(AbstractCharacter character, Types.Direction direction, bool clockWise, bool frozenForever) : base(character)
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
            // Can't change direction while frozen
        }

        public override void Freeze(bool frozenForever)
        {
            FrozenForever = frozenForever;
        }

        public override void Move()
        {
            // Cannot move while frozen
        }

        public override void Unfreeze() 
        {
            Character.State = new HandMovingState(Character, ClockWise, ResumeMovementDirection);
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            if (!FrozenForever) FrozenTimer += elapsedTime;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Sprite.Update();
        }
    }
}
