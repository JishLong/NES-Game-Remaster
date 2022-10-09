﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.GelStates
{
    public class GelMovingUpState : AbstractEnemyState
    {
        private Gel Gel;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        public GelMovingUpState(Gel gel)
        {
            Gel = gel;
            StateDirection = Direction.Up;
            DirectionVector = ToVector(StateDirection);
            Sprite = new GelSprite();
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
                    Gel.State = new GelMovingLeftState(Gel);
                    break;
                case Direction.Right:
                    Gel.State = new GelMovingRightState(Gel);
                    break;
                case Direction.Down:
                    Gel.State = new GelMovingDownState(Gel);
                    break;
            }
        }

        public override void Freeze()
        {
            Gel.State = new GelFrozenState(Gel, StateDirection);
        }

        public override void Move()
        {
            Gel.Position += DirectionVector * Gel.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
