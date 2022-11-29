using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.SnakeStates;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites;
using System;
using Sprint0.GameModes;

namespace Sprint0.Characters.Enemies
{
    public class Snake : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 2500;    // Change direction every this many milliseconds.

        private static readonly Random RNG = new();

        public Snake(Vector2 position)
        {
            // State
            State = new SnakeMovingState(this);

            // Combat
            Health = 1;
            Damage = 1;

            // Movement
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }

        public static ISprite GetSprite(ICharacterState state, Types.Direction direction)
        {
            return GameModeManager.GetInstance().GameMode.GetSnakeSprite(state, Types.Direction.UP);
        }
    }
}
