using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Aquamentus : AbstractCharacter
    {
        private double AttackTimer = 0;
        private readonly double AttackDelay = 3000;  // Attack every this many milliseconds.

        private double DirectionTime;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Aquamentus(Vector2 position) : base(Types.Character.AQUAMENTUS)
        {
            // State
            MovingState = new OrthogonalMovingState(this);
            FrozenTemporarilyState = new FrozenTemporarilyState(this);
            FrozenForeverState = new FrozenForeverState(this);
            AttackState = new AquamentusAttackState(this);

            MovingState.SetUp();
            CurrentState = MovingState;

            // The aquamentus sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = new AquamentusSprite();

            // Combat fields
            Health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt
            MovementSpeed = new(1.0f/3 * GameWindow.ResolutionScale, 1.0f/3 * GameWindow.ResolutionScale);

        // Movement fields
        Position = position;
        }

        public override void SetSprite(Types.Direction direction) 
        {
            // Do nothing
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            AttackTimer += elapsedTime;
            DirectionTime += elapsedTime;

            if ((AttackTimer - AttackDelay) > 0)
            {
                AttackTimer = 0;
                CurrentState.Attack();
            }

            if (DirectionTime - DirectionDelay > 0)
            {
                DirectionTime = 0;
                CurrentState.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
