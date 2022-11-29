using Microsoft.Xna.Framework;
using Sprint0.Characters.States.BatStates;
using Sprint0.GameModes;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class BatFrozenState: AbstractCharacterState
    {
        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public BatFrozenState(AbstractCharacter character, Types.Direction direction, bool frozenForever) : base(character)
        {
            ResumeMovementDirection = direction;
            FrozenForever = frozenForever;

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
            // If a bat is frozen from a boomerang, picking up a clock will keep it frozen forever
            // On the other hand, if a bat is frozen from a clock, we don't want the boomerang to "unfreeze" it
            if (frozenForever) FrozenForever = frozenForever;
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            if (inCurrentRoom) Character.State = new BatGameModeTransitionState(Character, oldGameMode, newGameMode, ResumeMovementDirection);
            else Character.Sprite = newGameMode.GetBatSprite(this, ResumeMovementDirection);
        }

        public override void Unfreeze()
        {
            Character.State = new BatMovingState(Character, ResumeMovementDirection);
        }

        public override void Update(GameTime gameTime)
        {
            if (!FrozenForever) FrozenTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Character.Sprite.Update();
        }
    }
}
