using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Projectiles.Player_Projectiles;
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

        public ProjectileHandler()
        {
            Projectiles = new List<IProjectile>();
        }

        public void AddProjectile(IProjectile projectile)
        {
            if (projectile is SwordProjectile) 
            {
                foreach (var proj in Projectiles) 
                {
                    if (proj is SwordProjectile || proj is SwordFlameProjectile) return;
                }
                AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().SwordShoot);
            }
            if (projectile is BoomerangProjectile) 
            {
                foreach (var proj in Projectiles)
                {
                    if (proj is BoomerangProjectile || proj.IsFromPlayer()) return;
                }
            }
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
            for (int i = Projectiles.Count - 1; i >= 0; i--) 
            {
                Projectiles[i].Update();
                if (Projectiles[i].TimeIsUp()) 
                {
                    Projectiles[i].DeathAction();
                    Projectiles.RemoveAt(i);
                }
            }
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
