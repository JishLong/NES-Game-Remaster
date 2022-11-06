using Microsoft.Xna.Framework;
using Sprint0.Characters.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingLeftState : AbstractCharacterState
    {
        private readonly RedGoriya Goriya;
        private readonly Vector2 DirectionVector = Sprint0.Utils.DirectionToVector(Types.Direction.LEFT);
        private readonly float MovementSpeed = 1.5f;
        public RedGoriyaMovingLeftState(RedGoriya goriya)
        {
            Goriya = goriya;
            Sprite = new RedGoriyaLeftSprite();
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
            Goriya.State = new RedGoriyaFrozenLeftState(Goriya);
        }
        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(Types.Direction.LEFT);
            switch (direction)
            {
                case Types.Direction.RIGHT:
                    Goriya.State = new RedGoriyaMovingRightState(Goriya);
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
