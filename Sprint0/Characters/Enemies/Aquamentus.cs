using System;
using Microsoft.Xna.Framework;
using Sprint0.Characters.Bosses.AquamentusStates;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Characters.Enemies
{
    public class Aquamentus : AbstractCharacter
    {
        private double ElapsedTime;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.

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

        public void Freeze()
        {
            State.Freeze();
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime - DirectionDelay > 0)
            {
                ElapsedTime = 0;
                State.ChangeDirection();
            }

            if (RNG.Next(0, 120) == 0)
            {
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOSS_PROJ, Position, Types.Direction.LEFT, null);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOSS_PROJ, Position, Types.Direction.DOWNLEFT, null);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOSS_PROJ, Position, Types.Direction.UPLEFT, null);
            }

            base.Update(gameTime);
        }
    }
}
