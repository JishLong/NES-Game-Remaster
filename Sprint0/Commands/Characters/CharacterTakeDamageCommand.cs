using Sprint0.Characters;
using Sprint0.Levels;

namespace Sprint0.Commands.Characters
{
    public class CharacterTakeDamageCommand : ICommand
    {
        private readonly ICharacter Character;
        private readonly int Damage;
        private readonly Room Room;
        private readonly Types.Direction PlayerSide;

        public CharacterTakeDamageCommand(ICharacter character, Types.Direction playerSide, int damage, Room room)
        {
            Character = character;
            Damage = damage;
            Room = room;
            PlayerSide = playerSide;
        }

        public void Execute()
        {
            Character.TakeDamage(PlayerSide, Damage, Room);
        }
    }
}
