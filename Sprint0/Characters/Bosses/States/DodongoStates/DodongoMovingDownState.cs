using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using System;
using static Sprint0.Characters.Bosses.Utils.BossUtils;
using Sprint0.Characters.Bosses.States.DodongoStates;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingDownState : AbstractBossState
    {
        private Dodongo Dodongo;
        private Vector2 DirectionVector = ToVector(Direction.Down);
        private float MovementSpeed = 2f;
        public DodongoMovingDownState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoDownSprite();
        }
        public override void Attack()
        {
            // Do nothing. (No Attack state)
        }
        public override void Move()
        {
            Dodongo.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Dodongo.State = new DodongoFrozenDownState(Dodongo);
        }
        public override void ChangeDirection()
        {
            Direction direction = RandOrthogDirection(Direction.Down);
            switch (direction)
            {
                case Direction.Left:
                    Dodongo.State = new DodongoMovingLeftState(Dodongo);
                    break;
                case Direction.Right:
                    Dodongo.State = new DodongoMovingRightState(Dodongo);
                    break;
                case Direction.Up:
                    Dodongo.State = new DodongoMovingUpState(Dodongo);
                    break;
            }
        }
        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}

