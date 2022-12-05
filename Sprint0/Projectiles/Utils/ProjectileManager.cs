using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Levels;

namespace Sprint0.Projectiles.Tools
{
    /* The purpose of this class is to provide a global point of management over projectiles;
     * 
     * This allows projectiles to be added/removed from the game from anywhere in the code - how convenient!
     * The scope of this power is limited to the current room that the player is in
     */
    public class ProjectileManager
    {
        // Single point of access
        private static ProjectileManager Instance;

        private Room CurrentRoom;

        private ProjectileManager() { }

        public static ProjectileManager GetInstance()
        {
            Instance ??= new ProjectileManager();
            return Instance;
        }

        public void AddProjectile(Types.Projectile proj, ICollidable user, Types.Direction direction)
        {
            CurrentRoom.AddProjectileToRoom(proj, user, direction);
        }

        public void RemoveProjectile(IProjectile proj)
        {
            CurrentRoom?.RemoveProjectileFromRoom(proj);
        }

        public void SetCurrentRoom(Room room)
        {
            CurrentRoom = room;
        }
    }
}
