using Microsoft.Xna.Framework;
using Sprint0.Characters;

namespace Sprint0.Commands.Character
{
    public class CharacterRelocateCommand : ICommand
    {
        private readonly ICharacter Character;
        private readonly Vector2 NewLoc;

        public CharacterRelocateCommand(ICharacter character, Vector2 newLoc)
        {
            Character = character;
            NewLoc = newLoc;
        }

        public void Execute()
        {
            Character.location(NewLoc);
        }
    }
}
