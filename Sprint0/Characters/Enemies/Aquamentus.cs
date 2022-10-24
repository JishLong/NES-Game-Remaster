using System;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles;
using Sprint0.Characters.Bosses.AquamentusStates;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Characters.Enemies
{
    public class Aquamentus : AbstractCharacter
    {
        private double ElapsedTime;
        private double DirectionDelay = 1000;    // Change direction every this many milliseconds.

        Random RNG;

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
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime - DirectionDelay > 0)
            {
                ElapsedTime = 0;
                State.ChangeDirection();
            }

            if (RNG.Next(0, 120) == 0)
            {
                IProjectile proj1 = ProjectileFactory.GetInstance().GetProjectile(
                    Types.Projectile.BOSSPROJ, Position, Types.Direction.LEFT, null);
                IProjectile proj2 = ProjectileFactory.GetInstance().GetProjectile(
                    Types.Projectile.BOSSPROJ, Position, Types.Direction.DOWNLEFT, null);
                IProjectile proj3 = ProjectileFactory.GetInstance().GetProjectile(
                    Types.Projectile.BOSSPROJ, Position, Types.Direction.DOWNRIGHT, null);

                //ProjectileManager.GetInstance().AddProjectile(proj1);
                //ProjectileManager.GetInstance().AddProjectile(proj2);
                //ProjectileManager.GetInstance().AddProjectile(proj3);
            }
            base.Update(gameTime);
        }
        public void Freeze()
        {
            State.Freeze();
        }
    }
}
