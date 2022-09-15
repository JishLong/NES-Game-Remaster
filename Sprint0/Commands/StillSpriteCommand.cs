using Sprint0.Sprites;

namespace Sprint0.Commands
{
    public class StillSpriteCommand : ICommand
    {
        private Game1 game;

        public StillSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute() 
        {
            if (game.sprite.GetType() != typeof(StillSprite)) 
            {
                game.sprite = new StillSprite();
            }
        }
    }
}
