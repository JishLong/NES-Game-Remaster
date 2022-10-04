using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Sprint0.Bosses.Utils;
using Sprint0.Sprites.Bosses;
using Sprint0.Characters;

namespace Sprint0.Bosses
{
    public class AquamentusFlame : AbstractBoss
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        Random RNG;
        int FlameNum;
        Vector2 firingPosition;

        public AquamentusFlame(int flameNum, Vector2 position, int updateTimer = 1000)
        {
            Health = 9999;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 1;    // Damage dealt
            CanMove = true;
            Position = position;
            firingPosition = position;
            Direction = new Vector2(0, 0);
            MovementSpeed = 3;
            UpdateTimer = updateTimer;
            Sprite = new Sprites.Bosses.AquamentusFlameSprite();
            FlameNum = flameNum;
        }

        public override void Destroy()
        {
            // no functionality 
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (true)
            {
                // TODO: add logic for refiring from Aquamentus position
                switch (FlameNum - 1)
                {
                    case 0:
                        Direction = new Vector2(-2, -1); // Upwards
                        break;

                    case 1:
                        Direction = new Vector2(-2, 0); // Straight
                        break;

                    case 2:
                       Direction = new Vector2(-2, 1); // Downwards
                        break;
                }
            }
            Position += (this.Direction * this.MovementSpeed);
            if (Position.X < -500 || Position.X > 1500 || Position.Y < -400 || Position.Y > 800)
            {
                Position = firingPosition;
            }

            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            System.Diagnostics.Debug.WriteLine("drawing from Flame: " + Position);
            Sprite.Draw(sb, Position);
        }

    }
}
