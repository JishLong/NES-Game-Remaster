using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Bosses.Utils;
using Sprint0.Sprites.Bosses;
using Sprint0.Sprites.Enemies;
using static Sprint0.Enemies.Utils.EnemyUtils;

namespace Sprint0.Bosses
{
    public class Dodongo : AbstractBoss
    {
        int ElapsedTime;
        int UpdateTimer;
        Random RNG;

        public Dodongo(Vector2 position, int updateTimer = 1000)
        {
            // Data
            Health = 1;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt

            // Movement
            CanMove = true;
            Position = position;
            Direction = new Vector2(0, 0); // Starts standing still.
            MovementSpeed = 2;

            // Update
            Sprite = new Sprites.Bosses.DodongoSprite();
            UpdateTimer = updateTimer;
            RNG = new Random();
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

                int randDirection = RNG.Next(0, 3);
                switch (randDirection)
                {
                    case 0:
                        Direction = new Vector2(1, 0); // right
                        Sprite = new Sprites.Bosses.DodongoRightSprite();
                        break;

                    case 1:
                        Direction = new Vector2(0, -1); // down
                        Sprite = new Sprites.Bosses.DodongoUpSprite();
                        break;

                    case 2:
                        Direction = new Vector2(-1, 0); // left
                        Sprite = new Sprites.Bosses.DodongoLeftSprite();
                        break;
                    case 3:
                        Direction = new Vector2(0, 1); // up
                        Sprite = new Sprites.Bosses.DodongoSprite();
                        break;
                }
            }
            Position += (Direction * MovementSpeed);

            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

    }
}
