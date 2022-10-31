using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingDownState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private readonly Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.DOWN);
        private readonly float MovementSpeed = 3f;
        public RedGoriyaMovingDownState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaDownSprite();
        }
        public override void Attack()
        {
            Goriya.State = new RedGoriyaAttackingDownState(Goriya);
        }
        public override void Move()
        {
            Goriya.Position += DirectionVector * MovementSpeed;
        }
        public override void Freeze()
        {
            Goriya.State = new RedGoriyaFrozenDownState(Goriya);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.DOWN);
            switch (direction)
            {
                case Types.Direction.RIGHT:
                    Goriya.State = new RedGoriyaMovingRightState(Goriya);
                    break;
                case Types.Direction.UP:
                    Goriya.State = new RedGoriyaMovingUpState(Goriya);
                    break;
                case Types.Direction.LEFT:
                    Goriya.State = new RedGoriyaMovingLeftState(Goriya);
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
