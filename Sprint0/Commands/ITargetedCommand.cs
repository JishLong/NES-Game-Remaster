using System;
using Sprint0.Player;

namespace Sprint0.Commands
{
	public interface ITargetedCommand : ICommand
	{
        public void SetTarget<T>(T target);
    }
}

