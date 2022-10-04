using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.Projectiles
{
    public class ProjectileManager
    {
        // Single point of use
        private static ProjectileManager Instance;

        private LinkedList<IProjectile> Projectiles;
        private LinkedList<IProjectile> ToBeRemoved;

        private ProjectileManager()
        {
            Projectiles = new LinkedList<IProjectile>();
            ToBeRemoved = new LinkedList<IProjectile>();
        }

        public void AddProjectile(IProjectile projectile) 
        {
            Projectiles.AddFirst(projectile);
        }

        public void RemoveAllProjectiles() 
        {
            Projectiles.Clear();
        }

        public void Update() 
        {
            foreach (var projectile in Projectiles) 
            {
                projectile.Update();
                if (projectile.TimeIsUp()) 
                {
                    ToBeRemoved.AddFirst(projectile);
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
