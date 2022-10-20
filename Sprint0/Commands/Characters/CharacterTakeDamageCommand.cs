using Sprint0.Characters;
using Sprint0.Levels;

namespace Sprint0.Commands.Characters
{
    public class CharacterTakeDamageCommand : ICommand
    {
        private readonly ICharacter Character;
        private readonly int Damage;
        private readonly Room Room;

        public CharacterTakeDamageCommand(ICharacter character, int damage, Room room)
        {
            Character = character;
            Damage = damage;
            Room = room;
        }

        public void Execute()
        {
            Character.TakeDamage(Damage, Room);
        }
    }
}
