using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies
{
    public class Dodongo : AbstractCharacter
    {
        private double DirectionTimer;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Dodongo(Vector2 position) : base(Character.DODONGO)
        {
            // State
            MovingState = new OrthogonalMovingState(this);
            FrozenTemporarilyState = new FrozenTemporarilyState(this);
            FrozenForeverState = new FrozenForeverState(this);
            AttackState = null;

            MovingState.SetUp();
            CurrentState = MovingState;

            // Combat fields
            Health = 1;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt
            MovementSpeed = new(2.0f / 3 * GameWindow.ResolutionScale, 2.0f / 3 * GameWindow.ResolutionScale);

            // Movement fields
            Position = position;
        }

        public override void SetSprite(Types.Direction direction)
        {
            Sprite = direction switch
            {
                Direction.LEFT => new DodongoLeftSprite(),
                Direction.RIGHT => new DodongoRightSprite(),
                Direction.UP => new DodongoUpSprite(),
                _ => new DodongoDownSprite(),
            };
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (DirectionTimer - DirectionDelay > 0)
            {
                DirectionTimer = 0;
                CurrentState.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
