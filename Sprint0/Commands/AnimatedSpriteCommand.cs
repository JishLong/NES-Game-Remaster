using Sprint0.Sprites;

namespace Sprint0.Commands
{
    public class AnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public AnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.sprite.GetType() != typeof(AnimatedSprite)) 
            {
                game.sprite = new AnimatedSprite();
            }
        }
    }
}
