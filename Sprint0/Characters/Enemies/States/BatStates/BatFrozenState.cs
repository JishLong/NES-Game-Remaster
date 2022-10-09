using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;
using System;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class BatFrozenState: AbstractEnemyState
    {
        private Bat Bat;
        private Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public BatFrozenState(Bat bat, Direction direction)
        {
            Bat = bat;
            ResumeMovementDirection= direction;
            Sprite = new BatSprite();

        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            switch (ResumeMovementDirection)
            {
                case Direction.Left:
                    Bat.State = new BatMovingLeftState(Bat);
                    break;
                case Direction.UpLeft:
                    Bat.State = new BatMovingUpLeftState(Bat);
                    break;
                case Direction.Up:
                    Bat.State = new BatMovingUpState(Bat);
                    break;
                case Direction.UpRight:
                    Bat.State = new BatMovingUpRightState(Bat);
                    break;
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
            }
        }

        public override void Freeze()
        {
            // Already frozen.
        }

        public override void Move()
        {
            // Cannot move while frozen.
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