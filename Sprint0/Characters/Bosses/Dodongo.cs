using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Bosses.States.DodongoStates;
using Sprint0.Sprites.Characters.Bosses;

namespace Sprint0.Characters.Bosses
{
    public class Dodongo : AbstractBoss
    {
        private double ElapsedTime;
        private double DirectionDelay = 1000;    // Change direction every this many milliseconds.

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

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((ElapsedTime - DirectionDelay) > 0)
            {
                ElapsedTime = 0;
                State.ChangeDirection();
            }

            State.Update(gameTime);
        }

        public void Freeze()
        {
            State.Freeze();
        }

        public override void Draw(SpriteBatch sb)
        {
            State.Draw(sb, Position);
        }

    }
}
