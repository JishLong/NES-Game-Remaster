using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.Projectiles.Tools
{
    /* The purpose of this class is to handle a collection of projectiles;
     * 
     * This mainly includes updating the projectiles' game logic and facilitating their rendering to the screen
     */
    public class ProjectileHandler : IController
    {
        private List<IProjectile> Projectiles;
        // This second list is used so that concurrent modification exceptions can be avoided
        private List<IProjectile> ToBeRemoved;

        public ProjectileHandler()
        {
            Projectiles = new List<IProjectile>();
            ToBeRemoved = new List<IProjectile>();
        }

        public void AddProjectile(IProjectile projectile)
        {
            Projectiles.Add(projectile);
        }

        public void RemoveProjectile(IProjectile projectile)
        {
            Projectiles.Remove(projectile);
        }

        public void RemoveAllProjectiles()
        {
            Projectiles.Clear();
        }

        public List<IProjectile> GetProjectiles()
        {
            return Projectiles;
        }

        public void Update()
        {      
            foreach (var projectile in Projectiles)
            {
                projectile.Update();
                if (projectile.TimeIsUp())
                {
                    ToBeRemoved.Add(projectile);
                }
            }
            foreach (var projectile in ToBeRemoved)
            {
                projectile.DeathAction();
                Projectiles.Remove(projectile);
            }
            ToBeRemoved.Clear();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Draw(sb);
            }
        }
    }
}
