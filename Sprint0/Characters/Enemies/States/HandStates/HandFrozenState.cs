using Microsoft.Xna.Framework;

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
            ResumeMovementDirection = direction;
            FrozenForever = frozenForever;
            ClockWise = clockWise;

            FrozenTimer = 0;
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
            // If a hand is frozen from a boomerang, picking up a clock will keep it frozen forever
            // On the other hand, if a hand is frozen from a clock, we don't want the boomerang to "unfreeze" it
            if (frozenForever) FrozenForever = frozenForever;
        }

        public override void Unfreeze() 
        {
            Character.State = new HandMovingState(Character, ClockWise, ResumeMovementDirection);
        }

        public override void Update(GameTime gameTime)
        {
            if (!FrozenForever) FrozenTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Character.Sprite.Update();
        }
    }
}
