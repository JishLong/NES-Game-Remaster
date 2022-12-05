using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.AquamentusStates;
using Sprint0.GameModes;
using Sprint0.Levels;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Characters.Enemies;
using System;

namespace Sprint0.Characters.Enemies
{
    public class Aquamentus : AbstractCharacter
    {
        private double AttackTimer = 0;
        private readonly double AttackDelay = 3000;  // Attack every this many milliseconds.

        private double DirectionTime;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Aquamentus(Vector2 position)
        {
            // State
            State = new AquamentusMovingState(this);

            // The aquamentus sprite is the same no matter its state, so we'll just instantiate it here
            Sprite = new AquamentusSprite();

            // Combat fields
            Health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt

            // Movement fields
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            AttackTimer += elapsedTime;
            DirectionTime += elapsedTime;

            if ((AttackTimer - AttackDelay) > 0)
            {
                AttackTimer = 0;
                State.Attack();
            }

            if (DirectionTime - DirectionDelay > 0)
            {
                DirectionTime = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
