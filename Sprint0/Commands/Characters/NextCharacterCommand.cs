using Microsoft.Xna.Framework;
using Sprint0.Characters;

namespace Sprint0.Commands.Characters
{
    public class NextCharacterCommand : ICommand
    {
        private Game1 Game;
        public NextCharacterCommand(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            Game.CurrentCharacter = CharacterFactory.GetInstance().GetNextCharacter(CharacterFactory.DefaultCharacterPosition);
        }
    }
}
