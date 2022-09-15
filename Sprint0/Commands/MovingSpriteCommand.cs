using Sprint0.Sprites;

namespace Sprint0.Commands
{
    public class MovingSpriteCommand : ICommand
    {
        private Game1 game;

        public MovingSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.sprite.GetType() != typeof(MovingSprite)) 
            {
                game.sprite = new MovingSprite();
            }
        }
    }
}
