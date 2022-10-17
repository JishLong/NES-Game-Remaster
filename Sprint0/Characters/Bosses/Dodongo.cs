using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Characters.Bosses;

namespace Sprint0.Characters.Bosses
{
    public class Dodongo : AbstractBoss
    {
        int ElapsedTime;
        int UpdateTimer;
        Random RNG;

        public Dodongo(Vector2 position, int updateTimer = 1000)
        {
            Health = 1;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt
            CanMove = true;
            Position = position;
            Direction = new Vector2(0, 0);
            MovementSpeed = 2;
            UpdateTimer = updateTimer;
            RNG = new Random();
            Sprite = new DodongoSprite();
        }

        public override void Destroy()
        {

            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;

                int randDirection = RNG.Next(0, 4);
                switch (randDirection)
                {
                    case 0:
                        Direction = new Vector2(1, 0); // right
                        Sprite = new DodongoRightSprite();
                        break;

                    case 1:
                        Direction = new Vector2(0, -1); // up
                        Sprite = new DodongoUpSprite();
                        break;

                    case 2:
                        Direction = new Vector2(-1, 0); // left
                        Sprite = new DodongoLeftSprite();
                        break;
                    case 3:
                        Direction = new Vector2(0, 1); // down
                        Sprite = new DodongoDownSprite();
                        break;
                }
            }
            Position += (Direction * MovementSpeed);
            Sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

    }
}
