using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Characters.Bosses;

namespace Sprint0.Bosses
{
    public class Dodongo : AbstractBoss
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        Random RNG;

        public Dodongo(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 1;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            this.Damage = 2;    // Damage dealt
            this.CanMove = true;
            this.Position = position;
            this.Direction = new Vector2(0, 0); // Starts standing still.
            this.MovementSpeed = 2;
            this.UpdateTimer = updateTimer;
            this.RNG = new Random();
            this.sprite = new DodongoSprite();
        }

        public override void Destroy()
        {
            // no functionality 
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > UpdateTimer)
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
            Position += (this.Direction * this.MovementSpeed);

            sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }

    }
}