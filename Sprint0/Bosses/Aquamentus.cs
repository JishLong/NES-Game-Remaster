using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Projectiles;

namespace Sprint0.Bosses
{
    public class Aquamentus : AbstractBoss
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        Random RNG;

        public Aquamentus(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            this.Damage = 2;    // Damage dealt
            this.CanMove = true;
            this.Position = position;
            this.Direction = new Vector2(0, 0); // Starts standing still.
            this.MovementSpeed = 2;
            this.UpdateTimer = updateTimer;
            this.RNG = new Random();
            this.sprite = new Sprites.Bosses.AquamentusSprite();
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

            sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }

    }
}
