using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingLeftState : AbstractEnemyState
    {
        private RedGoriya Goriya;
        private Vector2 DirectionVector = ToVector(Direction.Left);
        private float MovementSpeed = 2f;
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
            Direction direction = RandOrthogDirection(Direction.Left);
            switch (direction)
            {
                case Direction.Right:
                    Goriya.State = new RedGoriyaMovingRightState(Goriya);
                    break;
                case Direction.Up:
                    Goriya.State = new RedGoriyaMovingUpState(Goriya);
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
