using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.ZolStates
{
    public class ZolFrozenState: AbstractCharacterState
    {
        private Zol Zol;
        private Types.Direction ResumeMovementDirection;
        private double FrozenTimer;
        private double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.
        public ZolFrozenState(Zol zol, Types.Direction direction)
        {
            Zol = zol;
            ResumeMovementDirection = direction;
            Sprite = new ZolSprite();
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
                    Zol.State = new ZolMovingLeftState(Zol);
                    break;
                case Types.Direction.RIGHT:
                    Zol.State = new ZolMovingRightState(Zol);
                    break;
                case Types.Direction.DOWN:
                    Zol.State = new ZolMovingDownState(Zol);
                    break;
                case Types.Direction.UP:
                    Zol.State = new ZolMovingUpState(Zol);
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
