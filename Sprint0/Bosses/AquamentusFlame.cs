using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Bosses
{
    public class AquamentusFlame : AbstractBoss
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        Random RNG;
        int flameNum;

        public AquamentusFlame(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 9999;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            this.Damage = 1;    // Damage dealt
            this.CanMove = true;
            this.Position = position;
            this.Direction = new Vector2(0, 0); // Starts standing still.
            this.MovementSpeed = 3;
            this.UpdateTimer = updateTimer;
            this.sprite = new Sprites.Bosses.AquamentusFlameSprite();
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
                // TODO: add logic for refiring from Aquamentus position
                
                int flameNum = 1; // temp direction
                switch (flameNum)
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

            sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }

    }
}
