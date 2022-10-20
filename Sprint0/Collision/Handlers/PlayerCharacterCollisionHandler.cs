using Sprint0.Characters;
using Sprint0.Characters.Bosses;
using Sprint0.Characters.Enemies;
using Sprint0.Characters.Npcs;
using Sprint0.Commands.Characters;
using Sprint0.Commands.Player;
using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and characters
    public class PlayerCharacterCollisionHandler
    { 
        public PlayerCharacterCollisionHandler(Room room)
        {
            
        }

        /* This logic is very rudimentary, as Link's sword attack essentially gets treated as one giant rectangle that is 
         * almost impossible to actually hit anything with. Here is what will actually need to be done:
         * 
         * - Link's hitbox will ALWAYS remain a square instead of changing into a rectangle with the sword attack
         * - Link's sword attack will spawn an invisible projectile where the sword appears to be that lasts the duration
         *   of that swing
         * - This invisible projectile will be handled in character-projectile handling in order to damage characters
         */
        public void HandleCollision(IPlayer player, ICharacter character, Types.Direction playerSide, Room room)
        {
            if (player.IsPrimaryAttacking && player.FacingDirection == playerSide)
            {
                if (!character.GetType().IsAssignableTo(typeof(INpc)))
                {
                    new CharacterTakeDamageCommand(character, 1, room).Execute();
                    System.Diagnostics.Debug.WriteLine("Player has hit an enemy...");
                }
            }
            else 
            {             
                if (!character.GetType().IsAssignableTo(typeof(INpc)))
                {
                    new PlayerTakeDamageCommand(player).Execute();
                }
            }
        }
    }
}
