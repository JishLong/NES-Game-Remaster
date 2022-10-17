using Sprint0.Characters;
using Sprint0.Characters.Bosses;
using Sprint0.Characters.Enemies;
using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class PlayerCharacterCollisionHandler
    {
        private Room Room;

        public PlayerCharacterCollisionHandler(Room room)
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) isn't actually needed here -
         * at least I think... I'll keep it in the parameters for a while just in case...
         * 
         */
        public void HandleCollision(IPlayer player, ICharacter character, Types.Direction playerSide)
        {
            if (player.IsAttacking && player.FacingDirection == playerSide)
            {
                if (character.GetType().IsAssignableTo(typeof(IEnemy)))
                {
                    //new EnemyTakeDamageCommand((IEnemy)character, player).Execute();
                }
                else if (character.GetType().IsAssignableTo(typeof(IBoss))) 
                {
                    //new BossTakeDamageCommand((IBoss)character, player).Execute();
                }
            }
            else 
            {             
                if (character.GetType().IsAssignableTo(typeof(IEnemy)))
                {
                    //new PlayerTakeDamageCommand(player, (IEnemy)character).Execute();
                }
                else if (character.GetType().IsAssignableTo(typeof(IBoss)))
                {
                    //new PlayerTakeDamageCommand(player, (IBoss)character).Execute();
                }
            }
        }
    }
}
