using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites;
using static Sprint0.Types;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoFrozenState : AbstractCharacterState
    {
        private readonly static ISprite[] Sprites = {
            new DodongoUpSprite(), new DodongoDownSprite(), new DodongoLeftSprite(), new DodongoRightSprite()
        };

        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;

        public DodongoFrozenState(AbstractCharacter character, Types.Direction direction, bool frozenForever) : base(character)
        {
            Sprite = Sprites[(int)direction];
            ResumeMovementDirection = direction;
            FrozenForever = frozenForever;

            FrozenTimer = 0;
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            // Can't move while frozen
        }
        public override void Freeze(bool frozenForever)
        {
            FrozenForever = frozenForever;
        }
        public override void ChangeDirection()
        {
            // Do nothing. Cant change direction while frozen.
        }

        public override void Unfreeze()
        {
            Character.State = new DodongoMovingState(Character, ResumeMovementDirection);
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

