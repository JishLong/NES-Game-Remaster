using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Utils;
using Sprint0.Sprites.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class Hand : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;
        public Hand(Vector2 position, int updateTimer = 1000, string initialDirection = "UP")
        {
            // Combat
            this.Health = 1;

            // Movement
            this.Position = position;
            this.DirectionName = initialDirection;
            this.Direction= EnemyUtils.OrthogonalVectors[DirectionName];
            this.MovementSpeed = 2;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.sprite = new HandSprite();

        }
        public override void Destroy()
        {
            throw new NotImplementedException();
        }


        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
                Direction = EnemyUtils.RotateByAngle(Direction, 90);
            }

            Position += (this.Direction * this.MovementSpeed);
            sprite.Update(gameTime);
        }
        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}
