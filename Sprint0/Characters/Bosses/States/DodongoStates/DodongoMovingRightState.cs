using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using System;
using static Sprint0.Characters.Bosses.Utils.BossUtils;
using Sprint0.Characters.Bosses.States.DodongoStates;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingRightState : AbstractBossState
    {
        private Dodongo Dodongo;
        private Vector2 DirectionVector = ToVector(Direction.Right);
        private float MovementSpeed = 2f;
        public DodongoMovingRightState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoRightSprite();
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
            Dodongo.State = new DodongoFrozenRightState(Dodongo);
        }
        public override void ChangeDirection()
        {
            Direction direction = RandOrthogDirection(Direction.Right);
            switch (direction)
            {
                case Direction.Up:
                    Dodongo.State = new DodongoMovingUpState(Dodongo);
                    break;
                case Direction.Left:
                    Dodongo.State = new DodongoMovingLeftState(Dodongo);
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

