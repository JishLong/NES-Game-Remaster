using System;
using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.AquamentusStates;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Characters.Enemies
{
    public class Aquamentus : AbstractCharacter
    {
        private double DirectionTime;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        private double RoarTime;
        private readonly double RoarDelay = 3000;

        private readonly Random RNG;

        public Aquamentus(Vector2 position, int updateTimer = 1000)
        {
            // State fields
            State = new AquamentusMovingLeftState(this);

            // Combat fields
            Health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt

            // Movement fields
            Position = position;

            RNG = new Random();
        }

        public override void Update(GameTime gameTime)
        {
            DirectionTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (DirectionTime - DirectionDelay > 0)
            {
                DirectionTime = 0;
                State.ChangeDirection();
            }

            RoarTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (RoarTime - RoarDelay > 0)
            {
                RoarTime = 0;
                AudioManager.GetInstance().PlayOnce(Resources.BossNoise);
            }

            base.Update(gameTime);
        }
    }
}
