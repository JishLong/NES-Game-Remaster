using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.SkeletonStates
{
    public class SkeletonMovingDownState : AbstractCharacterState
    {
        private readonly Skeleton Skeleton;
        private readonly Types.Direction StateDirection;
        private readonly Vector2 DirectionVector;
        public SkeletonMovingDownState(Skeleton skeleton)
        {
            Skeleton = skeleton;
            StateDirection = Types.Direction.DOWN;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new SkeletonSprite();
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(StateDirection);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Skeleton.State = new SkeletonMovingLeftState(Skeleton);
                    break;
                case Types.Direction.RIGHT:
                    Skeleton.State = new SkeletonMovingRightState(Skeleton);
                    break;
                case Types.Direction.UP:
                    Skeleton.State = new SkeletonMovingUpState(Skeleton);
                    break;
            }
        }

        public override void Freeze()
        {
            Skeleton.State = new SkeletonFrozenState(Skeleton, StateDirection);
        }

        public override void Move()
        {
            Skeleton.Position += DirectionVector * Skeleton.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
