using Microsoft.Xna.Framework;
using Sprint0.Characters;

namespace Sprint0.Commands.Character
{
    public class CharacterRelocate : ICommand
    {
        private readonly ICharacter Character;
        private Vector2 NewLoc;

        public CharacterRelocate(ICharacter character, Vector2 newLoc)
        {
            Character = character;
            NewLoc = newLoc;
        }

        public void Execute()
        {
            Character.location(this.NewLoc);
        }
    }
}
