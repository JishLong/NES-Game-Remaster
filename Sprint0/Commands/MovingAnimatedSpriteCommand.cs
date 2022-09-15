using Sprint0.Sprites;

namespace Sprint0.Commands
{
    public class MovingAnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public MovingAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.sprite.GetType() != typeof(MovingAnimatedSprite)) 
            {
                game.sprite = new MovingAnimatedSprite();
            }     
        }
    }
}
