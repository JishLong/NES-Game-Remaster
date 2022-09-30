using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Enemies;
using Sprint0.Enemies.Behaviors;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies
{
    public class Skeleton : AbstractEnemy
    {
        public Skeleton(Vector2 position, float movementSpeed = 2)
        {
            // Combat
            Health = 1;

            // Movement
            Direction = Direction.Right;
            MovementBehavior = new OrthogonalMovementBehavior(movementSpeed, Direction);
            IsFrozen = false;
            Position = position;

            // Update related fields
            Sprite = new SkeletonSprite();
        }   

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
        
        public override void Update(GameTime gameTime)
        {
            if (!IsFrozen)
            {   
                Position += MovementBehavior.Move(gameTime);
            }

            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}
