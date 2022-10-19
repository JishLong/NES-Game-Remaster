using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Character;
using Sprint0.Projectiles.Character_Projectiles;
using Sprint0.Projectiles.Player;
using Sprint0.Projectiles.Player_Projectiles;
using System;

namespace Sprint0.Projectiles.Tools
{
    /* The purpose of this class is to allow a safer, abstracted view of creating projectiles that is available anywhere
     * in the code
     */
    public class ProjectileFactory
    {
        // Single point of access
        private static ProjectileFactory Instance;

        private ProjectileFactory() { }

        public IProjectile GetProjectile(Types.Projectile projectileType, Vector2 position, Types.Direction direction)
        {
            switch (projectileType)
            {
                case Types.Projectile.ARROWEXPLOSIONPROJ:
                    return new ArrowExplosionProjectile(position);
                case Types.Projectile.ARROWPROJ:
                    return new ArrowProjectile(position, direction);
                case Types.Projectile.BLUEARROWPROJ:
                    return new BlueArrowProjectile(position, direction);
                case Types.Projectile.BOMBEXPLOSIONPROJ:
                    return new BombExplosionProjectile(position);
                case Types.Projectile.BOMBPROJ:
                    return new BombProjectile(position);
                case Types.Projectile.BOSSPROJ:
                    return new BossProjectile(position, direction);           
                case Types.Projectile.FLAMEPROJ:
                    return new FlameProjectile(position, direction);
                case Types.Projectile.GORIYABOOMERANGPROJ:
                    return new GoriyaBoomerangProjectile(position, direction);
                case Types.Projectile.PLAYERBOOMERANGPROJ:
                    return new PlayerBoomerangProjectile(position, direction);
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
