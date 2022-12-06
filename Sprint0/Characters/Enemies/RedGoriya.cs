using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Types;
using Sprint0.Characters.Enemies.States;

namespace Sprint0.Characters.Enemies
{
    public class RedGoriya : AbstractCharacter
    {
        private double AttackTimer = 0;
        private readonly double AttackDelay = 4000;  // Attack every this many milliseconds.

        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1500;    // Change direction every this many milliseconds.

        public RedGoriya(Vector2 position) : base(Character.REDGORIYA)
        {
            // State
            MovingState = new OrthogonalMovingState(this);
            FrozenTemporarilyState = new FrozenTemporarilyState(this);
            FrozenForeverState = new FrozenForeverState(this);
            AttackState = new RedGoriyaAttackState(this);

            MovingState.SetUp();
            CurrentState = MovingState;

            // Combat
            Health = 3;
            Damage = 2;
            MovementSpeed = new Vector2(1.5f, 1.5f);

            // Movement
            Position = position;
        }

        public override void SetSprite(Types.Direction direction)
        {
            Sprite = direction switch
            {
                Direction.LEFT => new RedGoriyaLeftSprite(),
                Direction.RIGHT => new RedGoriyaRightSprite(),
                Direction.UP => new RedGoriyaUpSprite(),
                _ => new RedGoriyaDownSprite(),
            };
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            AttackTimer += elapsedTime;
            DirectionTimer += elapsedTime; 

            if ((AttackTimer - AttackDelay) > 0)
            {
                AttackTimer = 0;
                CurrentState.Attack();
            }

            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                CurrentState.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
