using System;
using Sprint0.Player;

namespace Sprint0.Commands.Player
{
	public interface ITargetedPlayerCommand : ICommand
	{
        public void SetTarget(IPlayer player);
    }
}

