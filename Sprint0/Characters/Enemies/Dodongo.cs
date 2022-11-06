using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.States.DodongoStates;

namespace Sprint0.Characters.Enemies
{
    public class Dodongo : AbstractCharacter
    {
        private double ElapsedTime;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        public Dodongo(Vector2 position, int updateTimer = 1000)
        {
            // State fields
            State = new DodongoMovingLeftState(this);

            // Combat fields
            Health = 1;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt

            // Movement fields
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime - DirectionDelay > 0)
            {
                ElapsedTime = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }    
    }
}
