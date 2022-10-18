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
        private PlayerItemCollisionHandler PlayerItemHandler;

        // Other handlers...

        public CollisionManager(Room room) 
        {
            PlayerItemHandler = new PlayerItemCollisionHandler(room);

            // Instantiation of other handlers...
        }

        public void HandleCollision(ICollidable CollidableA, ICollidable CollidableB, Types.Direction SideA) 
        {
            // Needed so that the collidable types can be checked more effectively
            FormatCollidables(CollidableA, CollidableB);

            if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(ICharacter)))
            {
                // Call the player-character handler
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IProjectile))) 
            {
                // Call the player-projectile handler
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                // Call the player-block handler
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IItem)))
            {
                PlayerItemHandler.HandleCollision((IPlayer)CollidableA, (IItem)CollidableB, SideA);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(ICharacter)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                // Call the character-block handler
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(ICharacter)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IProjectile)))
            {
                // Call the character-projectile handler
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IProjectile)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                // Call the projectile-block handler
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IBlock)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                // Call the block-block handler
            }
        }

        // This doesn't exist don't look here
        private void SwapCollidables(ICollidable CollidableA, ICollidable CollidableB)
        {
            ICollidable Temp = CollidableA;
            CollidableA = CollidableB;
            CollidableB = Temp;
        }

        // Why are you looking down here?????
        private void FormatCollidables(ICollidable CollidableA, ICollidable CollidableB)
        {
            if (CollidableB.GetType().IsAssignableTo(typeof(IPlayer)))
            {
                SwapCollidables(CollidableA, CollidableB);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IItem)))
            {
                SwapCollidables(CollidableA, CollidableB);
            }
            else if (CollidableB.GetType().IsAssignableTo(typeof(ICharacter)) && 
                !(CollidableA.GetType().IsAssignableTo(typeof(IPlayer))))
            {
                SwapCollidables(CollidableA, CollidableB);
            }
            else if (CollidableB.GetType().IsAssignableTo(typeof(IProjectile)) &&
                (CollidableA.GetType().IsAssignableTo(typeof(IBlock)) || CollidableA.GetType().IsAssignableTo(typeof(IItem))))
            {
                SwapCollidables(CollidableA, CollidableB);
            }
        }
    }
}
