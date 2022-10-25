using Microsoft.Xna.Framework;
using Sprint0.Collision;
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

        public IProjectile GetProjectile(Types.Projectile projectileType, Vector2 position, Types.Direction direction, ICollidable user)
        {
            switch (projectileType)
            {
                case Types.Projectile.ARROW_EXPLOSION_PARTICLE:
                    return new ArrowExplosionParticle(position);
                case Types.Projectile.ARROW_PROJ:
                    return new ArrowProjectile(position, direction);
                case Types.Projectile.BLUE_ARROW_PROJ:
                    return new BlueArrowProjectile(position, direction);
                case Types.Projectile.BOMB_EXPLOSION_PARTICLE:
                    return new BombExplosionParticle(position);
                case Types.Projectile.BOMB_PROJ:
                    return new BombProjectile(position);
                case Types.Projectile.BOSS_PROJ:
                    return new BossProjectile(position, direction);
                case Types.Projectile.DEATH_PARTICLE:
                    return new DeathParticle(position);                  
                case Types.Projectile.FLAME_PROJ:
                    return new FlameProjectile(position, direction);
                case Types.Projectile.GORIYA_BOOMERANG_PROJ:
                    return new GoriyaBoomerangProjectile(position, direction, user);
                case Types.Projectile.PLAYER_BOOMERANG_PROJ:
                    return new PlayerBoomerangProjectile(position, direction, user);
                case Types.Projectile.SWORD_MELEE:
                    return new SwordMelee(position, direction);
                case Types.Projectile.SWORD_PROJ:
                    return new SwordProjectile(position, direction);
                case Types.Projectile.SWORD_FLAME_PROJ:
                    return new SwordFlameProjectile(position, direction);
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
