using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Bosses;
using Sprint0.Sprites.Bosses;
using Sprint0.Bosses.Behaviors;

namespace Sprint0.Bosses
{
    public class Aquamentus : AbstractBoss
    {
        int ElapsedTime;
        int UpdateTimer;
        int CooldownTimer;
        Random RNG;

        AquamentusFlame Flame1;
        AquamentusFlame Flame2;
        AquamentusFlame Flame3;

        private float ProjectileSpeed;
        public Aquamentus(Vector2 position, int updateTimer = 1000)
        {
            // Data
            Health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt
            Flame1 = new AquamentusFlame(1, position);
            Flame2 = new AquamentusFlame(2, position);
            Flame3 = new AquamentusFlame(3, position);
            ProjectileSpeed = 4f;
            BossAttackBehavior = new AquamentusFlameBehavior(this, ProjectileSpeed);

            // Movement
            CanMove = true;
            Position = position;
            Direction = new Vector2(0, 0);
            MovementSpeed = 2;

            // Update 
            Sprite = new Sprites.Bosses.AquamentusSprite();
            UpdateTimer = updateTimer;
            CooldownTimer = 2500;
            RNG = new Random();
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            BossAttackBehavior = new AquamentusFlameBehavior(this, ProjectileSpeed);

            Flame1.Update(gameTime);
            Flame2.Update(gameTime);
            Flame3.Update(gameTime);

            if (ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
                BossAttackBehavior = new AquamentusFlameBehavior(this, ProjectileSpeed);
                Flame1.Update(gameTime);
                Flame2.Update(gameTime);
                Flame3.Update(gameTime);

                int randDirection = RNG.Next(0, 3);
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

            Position += (Direction * MovementSpeed);
            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
            Flame1.Draw(sb);
            Flame2.Draw(sb);
            Flame3.Draw(sb);
        }
    }
}
