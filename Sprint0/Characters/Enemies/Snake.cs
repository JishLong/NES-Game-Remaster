using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using Sprint0.Characters.Enemies.States;

namespace Sprint0.Characters.Enemies
{
    public class Snake : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 2500;    // Change direction every this many milliseconds.

        private static readonly Random RNG = new();

        public Snake(Vector2 position) : base(Types.Character.SNAKE)
        {
            // State
            MovingState = new SnakeMovingState(this);
            FrozenTemporarilyState = new FrozenTemporarilyState(this);
            FrozenForeverState = new FrozenForeverState(this);
            AttackState = null;

            MovingState.SetUp();
            CurrentState = MovingState;

            // Combat
            Health = 1;
            Damage = 1;
            MovementSpeed = new(2, 2);

            // Movement
            Position = position;
        }

        public override void SetSprite(Types.Direction direction)
        {
            if (direction == Types.Direction.LEFT) Sprite = new SnakeLeftSprite();
            else if (direction == Types.Direction.RIGHT) Sprite = new SnakeRightSprite();
            else
            {
                if (RNG.Next(2) > 0) Sprite = new SnakeLeftSprite();
                else Sprite = new SnakeRightSprite();
            }
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                CurrentState.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
