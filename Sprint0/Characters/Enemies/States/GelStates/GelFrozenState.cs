using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.GelStates
{
    public class GelFrozenState: AbstractEnemyState
    {
        private Gel Gel;
        private Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public GelFrozenState(Gel gel, Direction direction)
        {
            Gel = gel;
            ResumeMovementDirection = direction;
            Sprite = new GelSprite();
        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            switch (ResumeMovementDirection)
            {
                case Direction.Left:
                    Gel.State = new GelMovingLeftState(Gel);
                    break;
                case Direction.Right:
                    Gel.State = new GelMovingRightState(Gel);
                    break;
                case Direction.Down:
                    Gel.State = new GelMovingDownState(Gel);
                    break;
                case Direction.Up:
                    Gel.State = new GelMovingUpState(Gel);
                    break;
            }
        }

        public override void Freeze()
        {
            // Already frozen.
        }

        public override void Move()
        {
            // Cannot move while frozen
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            FrozenTimer += elapsedTime;

            if((FrozenTimer - FrozenDelay) > 0)
            {
                ChangeDirection();
            }
            Sprite.Update();
        }
    }
}
