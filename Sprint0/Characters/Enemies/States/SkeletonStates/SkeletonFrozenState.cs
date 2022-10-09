using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.SkeletonStates
{
    public class SkeletonFrozenState: AbstractEnemyState
    {
        private Skeleton Skeleton;
        private Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public SkeletonFrozenState(Skeleton skeleton, Direction direction)
        {
            Skeleton = skeleton;
            ResumeMovementDirection = direction;
            Sprite = new SkeletonSprite();
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
                    Skeleton.State = new SkeletonMovingLeftState(Skeleton);
                    break;
                case Direction.Right:
                    Skeleton.State = new SkeletonMovingRightState(Skeleton);
                    break;
                case Direction.Down:
                    Skeleton.State = new SkeletonMovingDownState(Skeleton);
                    break;
                case Direction.Up:
                    Skeleton.State = new SkeletonMovingUpState(Skeleton);
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
