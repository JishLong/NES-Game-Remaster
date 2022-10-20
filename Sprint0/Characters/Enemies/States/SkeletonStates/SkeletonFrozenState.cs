using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.SkeletonStates
{
    public class SkeletonFrozenState: AbstractCharacterState
    {
        private Skeleton Skeleton;
        private Types.Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public SkeletonFrozenState(Skeleton skeleton, Types.Direction direction)
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
                case Types.Direction.LEFT:
                    Skeleton.State = new SkeletonMovingLeftState(Skeleton);
                    break;
                case Types.Direction.RIGHT:
                    Skeleton.State = new SkeletonMovingRightState(Skeleton);
                    break;
                case Types.Direction.DOWN:
                    Skeleton.State = new SkeletonMovingDownState(Skeleton);
                    break;
                case Types.Direction.UP:
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
