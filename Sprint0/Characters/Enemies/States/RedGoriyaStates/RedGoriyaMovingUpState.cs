using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingUpState : AbstractEnemyState
    {
        private RedGoriya Goriya;
        private Vector2 DirectionVector = ToVector(Direction.Up);
        private float MovementSpeed = 2f;
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
            Direction direction = RandOrthogDirection(Direction.Up);
            switch (direction)
            {
                case Direction.Right:
                    Goriya.State = new RedGoriyaMovingRightState(Goriya);
                    break;
                case Direction.Left:
                    Goriya.State = new RedGoriyaMovingLeftState(Goriya);
                    break;
                case Direction.Down:
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
