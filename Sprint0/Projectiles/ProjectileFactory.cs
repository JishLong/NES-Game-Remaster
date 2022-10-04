using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Character_Projectiles;
using Sprint0.Projectiles.Player_Projectiles;
using System;

namespace Sprint0.Projectiles
{
    public class ProjectileFactory
    {
        // Single point of use
        private static ProjectileFactory Instance;

        private ProjectileFactory() { }

        public IProjectile GetProjectile(Types.Projectile projectileType, Vector2 position, Vector2 velocity)
        {
            switch (projectileType)
            {
                case Types.Projectile.BOSSPROJ:
                    return new BossProjectile(position, velocity);
                case Types.Projectile.BOMBPROJ:
                    return new BombProj(position, velocity);
                default:
                    Console.Error.Write("The projectile of type " + projectileType.ToString() +
                        " could not be instantiated by the Projectile Factory. Does this type exist?");
                    return null;
            }
        }

        public static ProjectileFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ProjectileFactory();
            }
            return Instance;
        }
    }
}
