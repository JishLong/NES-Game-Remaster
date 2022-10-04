using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.Projectiles
{
    public class ProjectileManager
    {
        // Single point of use
        private static ProjectileManager Instance;

        private LinkedList<IProjectile> projectiles;
        private LinkedList<IProjectile> toBeRemoved;

        private ProjectileManager()
        {
            projectiles = new LinkedList<IProjectile>();
            toBeRemoved = new LinkedList<IProjectile>();
        }

        public void addProjectile(IProjectile projectile) 
        {
            projectiles.AddFirst(projectile);
        }

        public void Update() 
        {
            foreach (var projectile in projectiles) 
            {
                projectile.Update();
                if (projectile.TimeIsUp()) 
                {
                    toBeRemoved.AddFirst(projectile);
                }
            }
            foreach (var projectile in toBeRemoved) 
            {
                projectiles.Remove(projectile);
            }
            toBeRemoved.Clear();
        }

        public void Draw(SpriteBatch sb) 
        {
            foreach (var projectile in projectiles)
            {
                projectile.Draw(sb);
            }
        }

        public static ProjectileManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ProjectileManager();
            }
            return Instance;
        }
    }
}
