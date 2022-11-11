using Microsoft.Xna.Framework;
using Sprint0.Characters;

namespace Sprint0.Commands.Character
{
    public class CharacterRelocateCommand : ICommand
    {
        private readonly ICharacter Character;
        private readonly Vector2 NewPosition;

        public CharacterRelocateCommand(ICharacter character, Vector2 newPosition)
        {
            Character = character;
            NewPosition = newPosition;
        }

        public void Execute()
        {
            Character.Position = NewPosition;
        }
    }
}
