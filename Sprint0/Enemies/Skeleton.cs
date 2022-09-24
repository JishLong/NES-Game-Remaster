using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Enemies
{
    public class Skeleton : AbstractEnemy
    {
        int ElapsedTime;    // Units: milliseconds 
        int UpdateTimer;    // Units: milliseconds 
        Random RNG;         // Random number generator;
        public Skeleton(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 1;
            // Movement
            this.CanMove = true;
            this.Position = position;
            this.Direction = new Vector2(1, 0); // Starts moving to the right.
            this.MovementSpeed = 3;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.RNG = new Random();

            this.sprite = new Sprites.Enemies.SkeletonSprite();
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

                int randDirection = this.RNG.Next(0, 3);
                switch (randDirection)
                {
                    case 0:
                        Direction = new Vector2(1, 0); // right
                        break;

                    case 1:
                        Direction = new Vector2(0, -1); // down
                        break;

                    case 2:
                        Direction = new Vector2(-1, 0); // left
                        break;
                    case 3:
                        Direction = new Vector2(0, 1); // up
                        break;
                }
            }

            // Move the skeleton.

            this.Position += (this.Direction * this.MovementSpeed);

            sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}
