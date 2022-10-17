using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using System;
using static Sprint0.Characters.Bosses.Utils.BossUtils;
using Sprint0.Characters.Bosses.States;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingUpState : AbstractBossState
    {
        private Dodongo Dodongo;
        private Vector2 DirectionVector = ToVector(Direction.Up);
        private float MovementSpeed = 2f;
        public DodongoMovingUpState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoUpSprite();
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
            Dodongo.State = new DodongoFrozenUpState(Dodongo);
        }
        public override void ChangeDirection()
        {
            Direction direction = RandOrthogDirection(Direction.Up);
            switch (direction)
            {
                case Direction.Left:
                    Dodongo.State = new DodongoMovingLeftState(Dodongo);
                    break;
                case Direction.Right:
                    Dodongo.State = new DodongoMovingRightState(Dodongo);
                    break;
                case Direction.Down:
                    Dodongo.State = new DodongoMovingDownState(Dodongo);
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

