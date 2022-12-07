using System;
using Sprint0.Player;

namespace Sprint0.Commands.Misc
{
	public class SetDefaultPlayerCommand : ITargetedCommand
	{
        private Game1 game;
        private IPlayer target;

		public SetDefaultPlayerCommand(Game1 game)
		{
            this.game = game;
            target = game.PlayerManager.GetDefaultPlayer();
		}

        public void Execute()
        {
            game.PlayerManager.SetDefaultPlayer(target.inputId);
        }

        public void SetTarget<T>(T target)
        {
            this.target = (IPlayer)target;
        }
    }
}

