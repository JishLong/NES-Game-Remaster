using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.Enemies.States;
using Sprint0.Sprites.Characters.Enemies;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;

namespace Sprint0.Characters.Enemies.RedGoriyaStates
{
    public class RedGoriyaMovingDownState : AbstractEnemyState
    {
        private RedGoriya Goriya;
        private Vector2 DirectionVector = ToVector(Direction.Down);
        private float MovementSpeed = 2f;
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
            Direction direction = RandOrthogDirection(Direction.Down);
            switch (direction)
            {
                case Direction.Right:
                    Goriya.State = new RedGoriyaMovingRightState(Goriya);
                    break;
                case Direction.Up:
                    Goriya.State = new RedGoriyaMovingUpState(Goriya);
                    break;
                case Direction.Left:
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
