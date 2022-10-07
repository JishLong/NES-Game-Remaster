using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Enemies.Behaviors;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies
{
    public class Gel : AbstractEnemy
    {
        public Gel(Vector2 position, float movementSpeed = 1, Direction direction = Direction.Right)
        {
            // Combat
            Health = 1;

            // Movement
            Direction = direction;
            Position = position;

            // Update related fields
            Sprite = new GelSprite();
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
