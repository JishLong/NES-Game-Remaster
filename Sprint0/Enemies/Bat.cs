using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{

    public class Bat : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;
        Random RNG;

        public Bat(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 1;
            // Movement
            this.CanMove = true;
            this.Position = position;
            this.Direction = new Vector2(0, 0); // Starts standing still.
            this.MovementSpeed = 2;

            // Update related fields
            this.UpdateTimer = updateTimer;
            this.RNG = new Random();
            this.sprite = new Sprites.Enemies.BatSprite();
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
                int randDirectionX = this.RNG.Next(-1, 2);
                int randDirectionY = this.RNG.Next(-1,2);

                Direction = new Vector2(randDirectionX, randDirectionY);
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
