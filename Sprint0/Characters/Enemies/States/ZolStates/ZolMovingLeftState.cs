﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.ZolStates
{
    public class ZolMovingLeftState: AbstractEnemyState
    {
        private Zol Zol;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        public ZolMovingLeftState(Zol zol)
        {
            Zol = zol;
            StateDirection = Direction.Left;
            DirectionVector = ToVector(StateDirection);
            Sprite = new ZolSprite();
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
                    Zol.State = new ZolMovingDownState(Zol);
                    break;
                case Direction.Right:
                    Zol.State = new ZolMovingRightState(Zol);
                    break;
                case Direction.Up:
                    Zol.State = new ZolMovingUpState(Zol);
                    break;
            }
        }

        public override void Freeze()
        {
            Zol.State = new ZolFrozenState(Zol, StateDirection);
        }

        public override void Move()
        {
            Zol.Position += DirectionVector * Zol.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}