using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Bosses;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using Sprint0.Characters.Bosses.States.DodongoStates;

namespace Sprint0.Characters.Bosses.States.DodongoStates
{
    public class DodongoMovingLeftState : AbstractBossState
    {
        private Dodongo Dodongo;
        private Vector2 DirectionVector = ToVector(Direction.Left);
        private float MovementSpeed = 2f;
        public DodongoMovingLeftState(Dodongo dodongo)
        {
            Dodongo = dodongo;
            //ResumeMovementDirection = direction;
            Sprite = new DodongoLeftSprite();
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
            Direction direction = RandOrthogDirection(Direction.Left);
            switch (direction)
            {
                case Direction.Up:
                    Dodongo.State = new DodongoMovingUpState(Dodongo);
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

