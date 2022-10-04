using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Enemies.Behaviors;
using static Sprint0.Enemies.Utils.EnemyUtils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Enemies
{
    public class Zol : AbstractEnemy
    {
        public Zol(Vector2 position, float movementSpeed = 1, Direction direction = Direction.Right)
        {
            // Combat
            Health = 1;

            // Movement
            Direction = direction;
            Position = position;
            MovementBehavior = new OrthogonalMovementBehavior(movementSpeed, Direction);

            // Update related fields
            Sprite = new ZolSprite();
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
