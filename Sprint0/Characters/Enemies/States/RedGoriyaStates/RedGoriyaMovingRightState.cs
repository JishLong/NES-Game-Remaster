using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingRightState : AbstractCharacterState
    {
        private RedGoriya Goriya;
        private Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.RIGHT);
        private float MovementSpeed = 2f;
        public RedGoriyaMovingRightState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaRightSprite();
        }
        public override void Attack()
        {
            Goriya.State = new RedGoriyaAttackingRightState(Goriya);
        }
        public override void Move()
        {
            Goriya.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenRightState(Goriya);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.RIGHT);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Goriya.State = new RedGoriyaMovingLeftState(Goriya);
                    break;
                case Types.Direction.UP:
                    Goriya.State = new RedGoriyaMovingUpState(Goriya);
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
