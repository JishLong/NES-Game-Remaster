using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Enemies.Behaviors;
using static Sprint0.Enemies.Utils.EnemyUtils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Enemies
{
    public class Skeleton : AbstractEnemy
    {
        public Skeleton(Vector2 position, float movementSpeed = 2, Direction direction = Direction.Right)
        {
            // Combat
            Health = 1;

            // Movement
            Position = position;
            Direction = direction;
            MovementBehavior = new OrthogonalMovementBehavior(movementSpeed, Direction);

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
            Sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}
