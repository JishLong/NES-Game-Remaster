﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.SkeletonStates
{
    public class SkeletonMovingLeftState: AbstractEnemyState
    {
        private Skeleton Skeleton;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        public SkeletonMovingLeftState(Skeleton skeleton)
        {
            Skeleton = skeleton;
            StateDirection = Direction.Left;
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
                case Direction.Down:
                    Skeleton.State = new SkeletonMovingDownState(Skeleton);
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
