using System;
using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public abstract class AbstractTargetedPlayerCommand : ITargetedPlayerCommand
    {
        private IPlayer target;

        public abstract void Execute();
        public void SetTarget(IPlayer player)
        {
            this.target = player;
        }
    }
}

