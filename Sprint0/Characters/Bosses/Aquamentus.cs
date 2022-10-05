using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;
using Sprint0.Sprites.Characters.Bosses;

namespace Sprint0.Bosses
{
    public class Aquamentus : AbstractBoss
    {
        int ElapsedTime;
        int UpdateTimer;

        Random RNG;

        public Aquamentus(Vector2 position, int updateTimer = 1000)
        {
            // Combat
            Health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            Damage = 2;    // Damage dealt
            CanMove = true;
            
            // Movement
            Position = position;
            Direction = new Vector2(0, 0); 
            MovementSpeed = 2;
            UpdateTimer = updateTimer;
            RNG = new Random();
            Sprite = new AquamentusSprite();
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

            if (RNG.Next(0, 120) == 0) 
            {
                IProjectile proj1 = ProjectileFactory.GetInstance().GetProjectile(
                    Types.Projectile.BOSSPROJ, Position, new Vector2(-3, 0));
                IProjectile proj2 = ProjectileFactory.GetInstance().GetProjectile(
                    Types.Projectile.BOSSPROJ, Position, new Vector2(-3, 3));
                IProjectile proj3 = ProjectileFactory.GetInstance().GetProjectile(
                    Types.Projectile.BOSSPROJ, Position, new Vector2(-3, -3));

                ProjectileManager.GetInstance().AddProjectile(proj1);
                ProjectileManager.GetInstance().AddProjectile(proj2);
                ProjectileManager.GetInstance().AddProjectile(proj3);
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
