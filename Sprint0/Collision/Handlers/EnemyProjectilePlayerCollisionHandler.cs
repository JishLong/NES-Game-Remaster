
using Sprint0.Characters;
using Sprint0.Characters.Enemies;
using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class EnemyProjectileCharacterCollisionHandler
    {
        private Room Room;

        public EnemyProjectileCharacterCollisionHandler(Room room)
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) is used to determine player knockback
         * 
         */
        public void HandleCollision(IPlayer player, IProjectile projectile, Types.Direction playerSide)
        {
            if (player.IsAttacking && player.FacingDirection == playerSide)
            {
                //if (character.GetType().IsAssignableTo(typeof(IEnemy)))
               // {
                    //new EnemyTakeDamageCommand((IEnemy)character, player).Execute();
               // }
              //  else if (character.GetType().IsAssignableTo(typeof(IBoss)))
               // {
                    //new BossTakeDamageCommand((IBoss)character, player).Execute();
              //  }
            }
            else
            {
              //  if (character.GetType().IsAssignableTo(typeof(IEnemy)))
              //  {
                    //new PlayerTakeDamageCommand(player, (IEnemy)character).Execute();
               // }
              //  else if (character.GetType().IsAssignableTo(typeof(IBoss)))
             //   {
                    //new PlayerTakeDamageCommand(player, (IBoss)character).Execute();
              //  }
            }
        }
    }
}
