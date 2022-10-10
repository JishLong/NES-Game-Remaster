﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class BatMovingUpRightState : AbstractEnemyState
    {
        private Bat Bat;
        private Direction StateDirection;
        private Vector2 DirectionVector;
        private float MovementSpeed = 2f;
        public BatMovingUpRightState(Bat bat)
        {
            Bat = bat;
            StateDirection = Direction.UpRight;
            DirectionVector = ToVector(StateDirection);
            Sprite = new BatSprite();

        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Direction direction = RandOmniDirection(StateDirection);
            switch (direction)
            {
                case Direction.Right:
                    Bat.State = new BatMovingRightState(Bat);
                    break;
                case Direction.DownRight:
                    Bat.State = new BatMovingDownRightState(Bat);
                    break;
                case Direction.Down:
                    Bat.State = new BatMovingDownState(Bat);
                    break;
                case Direction.DownLeft:
                    Bat.State = new BatMovingDownLeftState(Bat);
                    break;
                case Direction.Left:
                    Bat.State = new BatMovingLeftState(Bat);
                    break;
                case Direction.UpLeft:
                    Bat.State = new BatMovingUpLeftState(Bat);
                    break;
                case Direction.Up:
                    Bat.State = new BatMovingUpState(Bat);
                    break;
            }
        }

        public override void Freeze()
        {
            Bat.State = new BatFrozenState(Bat, StateDirection);
        }

        public override void Move()
        {
            Bat.Position += DirectionVector * Bat.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}