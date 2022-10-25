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
        private readonly List<IProjectile> Projectiles;
        // This second list is used so that concurrent modification isn't an issue
        private readonly List<IProjectile> ToBeRemoved;

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
            projectile.DeathAction();
            Projectiles.Remove(projectile);
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
                if (projectile.IsTimeUp())
                {
                    ToBeRemoved.Add(projectile);
                }
            }
            foreach (var projectile in ToBeRemoved)
            {
                RemoveProjectile(projectile);
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
