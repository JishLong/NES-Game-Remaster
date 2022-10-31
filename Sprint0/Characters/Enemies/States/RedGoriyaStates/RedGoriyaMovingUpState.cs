using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingUpState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private readonly Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.UP);
        private readonly float MovementSpeed = 3f;
        public RedGoriyaMovingUpState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaUpSprite();
        }
        public override void Attack()
        {
            Goriya.State = new RedGoriyaAttackingUpState(Goriya);
        }
        public override void Move()
        {
            Goriya.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenLeftState(Goriya);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.UP);
            switch (direction)
            {
                case Types.Direction.RIGHT:
                    Goriya.State = new RedGoriyaMovingRightState(Goriya);
                    break;
                case Types.Direction.LEFT:
                    Goriya.State = new RedGoriyaMovingLeftState(Goriya);
                    break;
                case Types.Direction.DOWN:
                    Goriya.State = new RedGoriyaMovingDownState(Goriya);
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
