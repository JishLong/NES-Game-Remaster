using Microsoft.Xna.Framework;
using Sprint0.Characters;

namespace Sprint0.Commands.Characters
{
    public class PrevCharacterCommand : ICommand
    {
        private Game1 Game;

        public PrevCharacterCommand(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            Game.CurrentCharacter = CharacterFactory.GetInstance().GetPrevCharacter(CharacterFactory.DefaultCharacterPosition);
        }
    }
}
