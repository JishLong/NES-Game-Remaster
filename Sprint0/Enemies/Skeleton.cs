using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using Sprint0.Enemies.Utils;
using Sprint0.Sprites.Enemies;

namespace Sprint0.Enemies
{
    public class Skeleton : AbstractEnemy
    {
        int ElapsedTime;    // Units: milliseconds 
        int UpdateTimer;    // Units: milliseconds 
        public Skeleton(Vector2 position, int updateTimer = 1000)
        {
            // Combat
            this.Health = 1;

            // Movement
            this.CanMove = true;
            this.Position = position;
            this.DirectionName = "UP";
            this.MovementSpeed = 2;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.sprite = new SkeletonSprite();
        }   

        public override void Destroy()
        {
            // not sure what to do here yet...
            throw new NotImplementedException();
        }
        
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
                Direction = EnemyUtils.RandOrthogDirection(ref DirectionName);
            }

            // Move the skeleton.
            Position += (this.Direction * this.MovementSpeed);
            sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}
