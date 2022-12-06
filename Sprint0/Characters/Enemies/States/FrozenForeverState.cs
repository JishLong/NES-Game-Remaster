using Microsoft.Xna.Framework;

namespace Sprint0.Characters.Enemies.States
{
    public class FrozenForeverState : AbstractCharacterState
    {
        private Types.Direction ResumeMovementDirection;

        public FrozenForeverState(AbstractCharacter character) : base(character) { }

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
            // Already frozen forever
        }

        public override void SetUp(Types.Direction direction)
        {
            Character.SetSprite(direction);
            ResumeMovementDirection = direction;
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
            Character.Sprite.Update();
        }
    }
}
