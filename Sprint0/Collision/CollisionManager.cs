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
        private PlayerCharacterCollisionHandler PlayerCharacterHandler;
        private PlayerItemCollisionHandler PlayerItemHandler;
        private EnemyProjectilePlayerCollisionHandler EnemyProjectilePlayerHandler;
        private EnemyProjectileBlockCollisionHandler EnemyProjectileBlockHandler;
        private PlayerBlockCollisionHandler PlayerBlockHandler;
        private CharacterBlockCollisionHandler CharacterBlockHandler;
        private PlayerProjEnemyCollisionHandler PlayerProjEnemyHandler;
        private PlayerProjBlockCollisionHandler PlayerProjBlockHandler;

        // Other handlers...

        public CollisionManager(Room room) 
        {
            PlayerCharacterHandler = new PlayerCharacterCollisionHandler(room);
            PlayerItemHandler = new PlayerItemCollisionHandler(room);
            EnemyProjectilePlayerHandler = new EnemyProjectilePlayerCollisionHandler(room);
            EnemyProjectileBlockHandler = new EnemyProjectileBlockCollisionHandler(room);
            PlayerBlockHandler = new PlayerBlockCollisionHandler(room);
            CharacterBlockHandler = new CharacterBlockCollisionHandler(room);
            PlayerProjEnemyHandler = new PlayerProjEnemyCollisionHandler();
            PlayerProjBlockHandler = new PlayerProjBlockCollisionHandler();

            // Instantiation of other handlers...
        }

        public void HandleCollision(ICollidable CollidableA, ICollidable CollidableB, Types.Direction SideA, Room room) 
        {
            // Needed so that the collidable types can be checked more effectively
            FormatCollidables(CollidableA, CollidableB);

            if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(ICharacter)))
            {
                PlayerCharacterHandler.HandleCollision((IPlayer)CollidableA, (ICharacter)CollidableB, SideA, room);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IProjectile))) 
            {
                if (!((IProjectile)CollidableB).FromPlayer())
                {
                    EnemyProjectilePlayerHandler.HandleCollision((IPlayer)CollidableA, (IProjectile)CollidableB, SideA, room);
                }
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                PlayerBlockHandler.HandleCollision((IPlayer)CollidableA, (IBlock)CollidableB, SideA, room);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IPlayer)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IItem)))
            {
                PlayerItemHandler.HandleCollision((IPlayer)CollidableA, (IItem)CollidableB, SideA, room);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(ICharacter)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                CharacterBlockHandler.HandleCollision((ICharacter)CollidableA, (IBlock)CollidableB, SideA, room);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(ICharacter)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IProjectile)))
            {
                // Call the character-projectile handler
                PlayerProjEnemyHandler.HandleCollision((IProjectile)CollidableB, (ICharacter)CollidableA);
            }
            else if (CollidableA.GetType().IsAssignableTo(typeof(IProjectile)) && 
                CollidableB.GetType().IsAssignableTo(typeof(IBlock)))
            {
                if (!((IProjectile)CollidableA).FromPlayer())
                {
                    //EnemyProjectileBlockHandler.HandleCollision((IProjectile)CollidableA, (IBlock)CollidableB, SideA, room);
                }
                else
                {
                    PlayerProjBlockHandler.HandleCollision((IProjectile)CollidableA);
                }
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
        // Forbidden fruit tastes the sweetest
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
