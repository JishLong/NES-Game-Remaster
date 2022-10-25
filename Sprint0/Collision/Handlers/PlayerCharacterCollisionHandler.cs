using Sprint0.Characters;
using Sprint0.Commands.Player;
using Sprint0.Levels;
using Sprint0.Npcs;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and characters
    public class PlayerCharacterCollisionHandler
    { 
        // NOTE: enemies still need to have different contact attack damage amounts; this is not yet accounted for here
        public void HandleCollision(IPlayer player, ICharacter character, Types.Direction playerSide, Room room)
        {
            if (!(character is OldMan) && !(character is Flame)) new PlayerTakeDamageCommand(player, playerSide, 1).Execute();
        }
    }
}
