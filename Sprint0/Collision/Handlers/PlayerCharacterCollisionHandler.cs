using Sprint0.Characters;
using Sprint0.Commands.Player;
using Sprint0.Npcs;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and characters
    public class PlayerCharacterCollisionHandler
    { 
        // NOTE: enemies have not yet been assigned contact damage values, so for now the player will simply take 1 point of damage
        public void HandleCollision(IPlayer player, ICharacter character, Types.Direction playerSide)
        {
            if (character is not OldMan && character is not Flame) new PlayerTakeDamageCommand(player, playerSide, 1).Execute();
        }
    }
}
