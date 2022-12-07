using Microsoft.Xna.Framework;

namespace Sprint0.Characters.Enemies.States
{
    public class FrozenTemporarilyState : AbstractCharacterState
    {
        private Types.Direction ResumeMovementDirection;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public FrozenTemporarilyState(AbstractCharacter character) : base(character) { }

        public override void Attack()
        {
            // Can't attack while frozen
        }

        public override void ChangeDirection()
        {
            // Can't change direction while frozen
        }

        public override void Freeze(bool frozenForever)
        {
            // If a bat is frozen from a boomerang, picking up a clock will keep it frozen forever
            // On the other hand, if a bat is frozen from a clock, we don't want the boomerang to "unfreeze" it
            if (frozenForever && Character.FrozenForeverState != null) 
            {
                Character.FrozenForeverState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.FrozenForeverState;
            }
        }

        public override void SetUp(Types.Direction direction)
        {
            Character.SetSprite(direction);
            ResumeMovementDirection = direction;
            FrozenTimer = 0;
        }

        public override void Unfreeze()
        {
            if (Character.MovingState != null)
            {
                Character.MovingState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.MovingState;
            }
            else if (Character.AttackState != null)
            {
                Character.AttackState.SetUp(ResumeMovementDirection);
                Character.CurrentState = Character.AttackState;
            }
        }

        public override void Update(GameTime gameTime)
        {
            FrozenTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Character.Sprite.Update();
        }
    }
}
