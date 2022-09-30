using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Behaviors;
using Sprint0.Enemies.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Enemies
{

    public class Bat : AbstractEnemy
    {
        public Bat(Vector2 position, float movementSpeed = 2)
        {
            // Combat
            Health = 1;

            // Movement
            Direction = Direction.Right;
            MovementBehavior = new OmniDirectionalMovementBehavior(movementSpeed, Direction);
            IsFrozen = false;
            Position = position;

            // Update related fields
            Sprite = new Sprites.Enemies.BatSprite();
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
