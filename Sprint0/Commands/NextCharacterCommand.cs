using Microsoft.Xna.Framework;

namespace Sprint0.Commands
{
    public class NextCharacterCommand : ICommand
    {
        private Game1 game;
        private Vector2 DefaultCharacterPosition;

        public NextCharacterCommand(Game1 game)
        {
            this.game = game;
            this.DefaultCharacterPosition = new Vector2(500, 200);
        }
        public void Execute()
        {
            game.currentCharacterIndex = (game.currentCharacterIndex + 1) % game.characters.Length;
        }
    }
}
