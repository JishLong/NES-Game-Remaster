using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using Sprint0.Characters.Bosses.States.DodongoStates;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoFrozenRightState : AbstractBossState
    {
        private Dodongo Dodongo;
        private Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;
        public DodongoFrozenRightState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoRightSprite();
        }
        public override void Attack()
        {
            // Do nothing. (Cant attack after frozen.)
        }
        public override void Move()
        {
            Dodongo.State = new DodongoMovingRightState(Dodongo);
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

