using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.BatStates
{
    public class BatFrozenState: AbstractCharacterState
    {
        private Bat Bat;
        private Types.Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public BatFrozenState(Bat bat, Types.Direction direction)
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
                case Types.Direction.LEFT:
                    Bat.State = new BatMovingLeftState(Bat);
                    break;
                case Types.Direction.UPLEFT:
                    Bat.State = new BatMovingUpLeftState(Bat);
                    break;
                case Types.Direction.UP:
                    Bat.State = new BatMovingUpState(Bat);
                    break;
                case Types.Direction.UPRIGHT:
                    Bat.State = new BatMovingUpRightState(Bat);
                    break;
                case Types.Direction.RIGHT:
                    Bat.State = new BatMovingRightState(Bat);
                    break;
                case Types.Direction.DOWNRIGHT:
                    Bat.State = new BatMovingDownRightState(Bat);
                    break;
                case Types.Direction.DOWN:
                    Bat.State = new BatMovingDownState(Bat);
                    break;
                case Types.Direction.DOWNLEFT:
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