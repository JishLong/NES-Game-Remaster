using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.GelStates
{
    public class GelFrozenState : AbstractCharacterState
    {
        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public GelFrozenState(AbstractCharacter character, Types.Direction direction, bool frozenForever) : base(character)
        {
            Sprite = new BatSprite();
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
            FrozenForever = frozenForever;
        }

        public override void Move()
        {
            // Cannot move while frozen.
        }

        public override void Unfreeze()
        {
            Character.State = new GelMovingState(Character, ResumeMovementDirection);
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