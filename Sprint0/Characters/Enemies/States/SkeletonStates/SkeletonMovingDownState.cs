using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.SkeletonStates
{
    public class SkeletonMovingDownState : AbstractEnemyState
    {
        private Skeleton Skeleton;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        public SkeletonMovingDownState(Skeleton skeleton)
        {
            Skeleton = skeleton;
            StateDirection = Direction.Down;
            DirectionVector = ToVector(StateDirection);
            Sprite = new SkeletonSprite();
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Direction direction = RandOrthogDirection(StateDirection);
            switch (direction)
            {
                case Direction.Left:
                    Skeleton.State = new SkeletonMovingLeftState(Skeleton);
                    break;
                case Direction.Right:
                    Skeleton.State = new SkeletonMovingRightState(Skeleton);
                    break;
                case Direction.Up:
                    Skeleton.State = new SkeletonMovingUpState(Skeleton);
                    break;
            }
        }

        public override void Freeze()
        {
            Skeleton.State = new SkeletonFrozenState(Skeleton, StateDirection);
        }

        public override void Move()
        {
            Skeleton.Position += DirectionVector * Skeleton.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
