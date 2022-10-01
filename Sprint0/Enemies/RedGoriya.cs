using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;
using System;
using Sprint0.Enemies.Behaviors;
using System.Collections.Generic;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies
{
    public class RedGoriya : AbstractEnemy 
    {
        private Dictionary<Direction, IEnemySprite> DirectionSprites = new Dictionary<Direction, IEnemySprite>()
        {
            {Direction.Up, new RedGoriyaUpSprite()},
            {Direction.Down, new RedGoriyaDownSprite()},
            {Direction.Left, new RedGoriyaLeftSprite()},
            {Direction.Right, new RedGoriyaRightSprite()},
        };

        private Dictionary<Direction, IEnemySprite> AttackSprites = new Dictionary<Direction, IEnemySprite>() 
        {
            {Direction.Up, new RedGoriyaUpSprite()},
            {Direction.Down, new RedGoriyaDownSprite()},
            {Direction.Left, new RedGoriyaLeftSprite()},
            {Direction.Right, new RedGoriyaRightSprite()},
        };

        private float ProjectileSpeed;

        private double ElapsedTime;
        private double AttackTimer;
        public RedGoriya(Vector2 position, Direction direction = Direction.Right, float movementSpeed = 2) 
        {
            // Combat
            Health = 1;
            ProjectileSpeed = 3;
            AttackBehavior = new BoomerangAttackBehavior(this, ProjectileSpeed);

            // Movement
            IsFrozen = false;
            Position = position;
            Direction = direction;
            MovementBehavior = new OrthogonalMovementBehavior(movementSpeed, Direction);

            // Update related fields
            Sprite = DirectionSprites[MovementBehavior.GetDirection()];
            ElapsedTime = 0;
            AttackTimer = 3000;

        }
        public override void Destroy()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (!IsFrozen)  // If not frozen, this enemy can move.
            {
                DoMove(gameTime);
            }
           
            if((ElapsedTime - AttackTimer) > 0)
            {
                ElapsedTime = 0;
                DoAttack(gameTime);
            }

            AttackBehavior.Update(gameTime);
            Sprite.Update(gameTime);
        }

        private void DoMove(GameTime gameTime)
        {
            // Adds the total movement for this frame to the current position.
            Position += MovementBehavior.Move(gameTime);
            Direction = MovementBehavior.GetDirection();
            Sprite = DirectionSprites[Direction];
        }
        private void DoAttack(GameTime gameTime)
        {
            AttackBehavior.Attack(Position, Direction);
            Sprite = AttackSprites[Direction];
        }
        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
            AttackBehavior.Draw(sb);
        }
    }
}
