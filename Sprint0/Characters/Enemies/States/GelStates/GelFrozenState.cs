using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.GelStates
{
    public class GelFrozenState: AbstractCharacterState
    {
        private Gel Gel;
        private Types.Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public GelFrozenState(Gel gel, Types.Direction direction)
        {
            Gel = gel;
            ResumeMovementDirection = direction;
            Sprite = new GelSprite();
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
                    Gel.State = new GelMovingLeftState(Gel);
                    break;
                case Types.Direction.RIGHT:
                    Gel.State = new GelMovingRightState(Gel);
                    break;
                case Types.Direction.DOWN:
                    Gel.State = new GelMovingDownState(Gel);
                    break;
                case Types.Direction.UP:
                    Gel.State = new GelMovingUpState(Gel);
                    break;
            }
        }

        public override void Freeze()
        {
            // Already frozen.
        }

        public override void Move()
        {
            // Cannot move while frozen
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
