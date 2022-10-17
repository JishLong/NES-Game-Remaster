using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using System;
using static Sprint0.Characters.Bosses.Utils.BossUtils;
using Sprint0.Characters.Bosses.AquamentusStates;

namespace Sprint0.Characters.Bosses.States.AquamentusStates
{
    public class AquamentusFrozenState : AbstractBossState
    {
        private Aquamentus Aquamentus;
        private Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;
        public AquamentusFrozenState(Aquamentus aquamentus)
        {
            Aquamentus = aquamentus;
            //ResumeMovementDirection = direction;
            Sprite = new AquamentusSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Aquamentus.State = new AquamentusMovingLeftState(Aquamentus);
        }
        public override void Freeze()
        {
            // Already frozen.
        }
        public override void ChangeDirection()
        {
            // Do nothing. Cant change direction while frozen.
        }
        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            FrozenTimer += elapsedTime;

            if ((FrozenTimer - FrozenDelay) > 0)
            {
                ChangeDirection();
            }
            Sprite.Update();
        }
    }
}

