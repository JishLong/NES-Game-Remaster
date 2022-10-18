using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.Projectiles
{
    public class ProjectileManager
    {
        // Single point of use
        private static ProjectileManager Instance;

        private List<IProjectile> Projectiles;
        private List<IProjectile> ToBeRemoved;

        private ProjectileManager()
        {
            Projectiles = new List<IProjectile>();
            ToBeRemoved = new List<IProjectile>();
        }

        public void AddProjectile(IProjectile projectile) 
        {
            Projectiles.Add(projectile);
        }

        public void RemoveAllProjectiles() 
        {
            Projectiles.Clear();
        }

        public void RemoveProjectile(IProjectile projectile)
        {
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
                if (projectile.TimeIsUp()) 
                {
                    ToBeRemoved.Add(projectile);
                }
            }
            foreach (var projectile in ToBeRemoved) 
            {
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
