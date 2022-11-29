using Microsoft.Xna.Framework;
using Sprint0.Characters.States.BatStates;
using Sprint0.Characters.States.DodongoStates;
using Sprint0.GameModes;
using static Sprint0.Types;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoFrozenState : AbstractCharacterState
    {
        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;

        public DodongoFrozenState(AbstractCharacter character, Types.Direction direction, bool frozenForever) : base(character)
        {
            ResumeMovementDirection = direction;
            FrozenForever = frozenForever;

            FrozenTimer = 0;
        }

        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }

        public override void Freeze(bool frozenForever)
        {
            // If a dodongo is frozen from a boomerang, picking up a clock will keep it frozen forever
            // On the other hand, if a dodongo is frozen from a clock, we don't want the boomerang to "unfreeze" it
            if (frozenForever) FrozenForever = frozenForever;
        }

        public override void ChangeDirection()
        {
            // Do nothing. Cant change direction while frozen.
        }

        public override void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom)
        {
            if (inCurrentRoom) Character.State = new DodongoGameModeTransitionState(Character, oldGameMode, newGameMode, ResumeMovementDirection);
            else Character.Sprite = newGameMode.GetDodongoSprite(this, ResumeMovementDirection);
        }

        public override void Unfreeze()
        {
            Character.State = new DodongoMovingState(Character, ResumeMovementDirection);
        }

        public override void Update(GameTime gameTime)
        {
            if (!FrozenForever) FrozenTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Character.Sprite.Update();
        }
    }
}
