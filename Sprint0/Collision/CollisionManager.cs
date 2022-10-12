using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Collision.Handlers;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles;

namespace Sprint0.Collision
{
    /* DEV NOTES:
     * 
     * The collision manager's job is to figure out what specific kind of collision has occurred - for example, is it one in which
     * the player is the affected object and a block is the acting object (player-block collision)?
     * 
     * Once the collision manager has done this, it routes the affected/acting objects and side (obtained from the collision
     * detector) to an appropriate collision handler that is capable of handling that specific type of collision
     * 
     */
    public class CollisionManager
    {
        private ItemPlayerCollisionHandler ItemPlayerHandler;

        // Other handlers...

        public CollisionManager(Room room) 
        {
            ItemPlayerHandler = new ItemPlayerCollisionHandler(room);

            // Instantiation of other handlers...
        }

        public void HandleCollision(ICollidable affectedCollidable, ICollidable actingCollidable, Types.Direction affectedSide) 
        {
            int index = 0;
            if (affectedCollidable.GetType() == typeof(IPlayer) && actingCollidable.GetType() == typeof(ICharacter))
            {
                // Call the player-character handler
            }
            else if (affectedCollidable.GetType() == typeof(IPlayer) && actingCollidable.GetType() == typeof(IProjectile)) 
            {
                // Call the player-projectile handler
            }
            else if (affectedCollidable.GetType() == typeof(IPlayer) && actingCollidable.GetType() == typeof(IBlock))
            {
                // Call the player-block handler
            }
            else if (affectedCollidable.GetType() == typeof(IPlayer) && actingCollidable.GetType() == typeof(IItem))
            {
                // Call the player-item handler
            }
            else if (affectedCollidable.GetType() == typeof(ICharacter) && actingCollidable.GetType() == typeof(IPlayer))
            {
                // Call the character-player handler
            }
            if (affectedCollidable.GetType() == typeof(ICharacter) && actingCollidable.GetType() == typeof(IBlock))
            {
                // Call the character-block handler
            }
            else if (affectedCollidable.GetType() == typeof(ICharacter) && actingCollidable.GetType() == typeof(IProjectile))
            {
                // Call the character-projectile handler
            }
            else if (affectedCollidable.GetType() == typeof(IProjectile) && actingCollidable.GetType() == typeof(IPlayer))
            {
                // Call the projectile-player handler
            }
            else if (affectedCollidable.GetType() == typeof(IProjectile) && actingCollidable.GetType() == typeof(ICharacter))
            {
                // Call the projectile-character handler
            }
            else if (affectedCollidable.GetType() == typeof(IProjectile) && actingCollidable.GetType() == typeof(IBlock))
            {
                // Call the projectile-block handler
            }
            else if (affectedCollidable.GetType() == typeof(IBlock) && actingCollidable.GetType() == typeof(IPlayer))
            {
                // Call the block-player handler
            }
            else if (affectedCollidable.GetType() == typeof(IBlock) && actingCollidable.GetType() == typeof(IBlock))
            {
                // Call the block-block handler
            }
            else if (affectedCollidable.GetType() == typeof(IItem) && actingCollidable.GetType() == typeof(IPlayer))
            {
                ItemPlayerHandler.HandleCollision((IItem)affectedCollidable, (IPlayer)actingCollidable, affectedSide);
            }
        }
    }
}
