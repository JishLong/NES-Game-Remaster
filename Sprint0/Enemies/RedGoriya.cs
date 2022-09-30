using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Enemies;
using System;
using Sprint0.Enemies.Behaviors;
using System.Collections.Generic;
using static Sprint0.Enemies.Utils.EnemyUtils;
using Sprint0.Npcs;

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

        private float ProjectileSpeed;
        public RedGoriya(Vector2 position, Direction direction = Direction.Right, float movementSpeed = 2) 
        {
            // Combat
            Health = 1;
            ProjectileSpeed = 3;
            AttackBehavior = new BoomerangAttackBehavior(ProjectileSpeed);

            // Movement
            IsFrozen = false;
            Position = position;
            Direction = direction;
            MovementBehavior = new OrthogonalMovementBehavior(movementSpeed, Direction);

            // Update related fields
            Sprite = DirectionSprites[MovementBehavior.GetDirection()];
        }
        public override void Destroy()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            if (!IsFrozen)  // If not, this enemy can move, attack, etc...
            {
                // Adds the total movement for this frame to the current position.
                Position += MovementBehavior.Move(gameTime);
                Direction = MovementBehavior.GetDirection();
                Sprite = DirectionSprites[Direction];

                AttackBehavior.Attack(gameTime, Direction);
            }
            Sprite.Update(gameTime);
        }
        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
            AttackBehavior.Draw(sb);
        }
    }
}
