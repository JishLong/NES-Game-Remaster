using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Enemies;
using Sprint0.Enemies.Behaviors;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies
{
    public class Hand : AbstractEnemy
    {
        public Hand(Vector2 position, float movementSpeed = 2, Direction direction = Direction.Up)
        {
            // Combat
            Health = 1;

            // Movement
            Position = position;
            Direction = direction;
            MovementBehavior = new SquareMovementBehavior(movementSpeed, Direction);

            // Update related fields
            Sprite = new HandSprite();
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
