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

        public IProjectile GetProjectile(Types.Projectile projectileType, ICollidable user, Types.Direction direction)
        {
            switch (projectileType)
            {
                case Types.Projectile.ARROW_EXPLOSION_PARTICLE:
                    return new ArrowExplosionParticle(user, direction);
                case Types.Projectile.ARROW_PROJ:
                    return new ArrowProjectile(user, direction);
                case Types.Projectile.BLUE_ARROW_PROJ:
                    return new BlueArrowProjectile(user, direction);
                case Types.Projectile.BOMB_EXPLOSION_PARTICLE:
                    return new BombExplosionParticle(user, direction);
                case Types.Projectile.BOMB_PROJ:
                    return new BombProjectile(user, direction);
                case Types.Projectile.BOOMERANG_PROJ:
                    return new BoomerangProjectile(user, direction);
                case Types.Projectile.BOSS_PROJ:
                    return new BossProjectile(user, direction);
                case Types.Projectile.DEATH_PARTICLE:
                    return new DeathParticle(user);                  
                case Types.Projectile.FLAME_PROJ:
                    return new FlameProjectile(user, direction);
                case Types.Projectile.OLDMAN_PROJ:
                    return new OldManProjectile(user);
                case Types.Projectile.SPAWN_PARTICLE:
                    return new SpawnParticle(user);
                case Types.Projectile.SWORD_MELEE:
                    return new SwordMelee(user, direction);
                case Types.Projectile.SWORD_PROJ:
                    return new SwordProjectile(user, direction);
                case Types.Projectile.SWORD_FLAME_PROJ:
                    return new SwordFlameProjectile(user, direction);  
                default:
                    Console.Error.Write("The projectile of type " + projectileType.ToString() +
                        " could not be instantiated by the Projectile Factory. Does this type exist?");
                    return null;
            }
        }

        public static ProjectileFactory GetInstance()
        {
            Instance ??= new ProjectileFactory();
            return Instance;
        }
    }
}
