using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Enemies.Behaviors;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
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

            // Update related fields
            Sprite = new HandSprite();
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }
    }
}
