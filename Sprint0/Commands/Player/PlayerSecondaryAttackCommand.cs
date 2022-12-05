using System;
using Sprint0.Player;

namespace Sprint0.Commands.Player
{
	public class PlayerSecondaryAttackCommand : ITargetedCommand
	{
        private IPlayer target;

		public PlayerSecondaryAttackCommand(IPlayer target)
		{
            this.target = target;
		}

        public void Execute()
        {
            if (target.Inventory.HasItem(Types.Item.RUPEE)
                && target.Inventory.GetAmount(Types.Item.RUPEE) > 0)
            {
                target.DoSecondaryAttack();
            }
        }

        public void SetTarget<T>(T target)
        {
            this.target = (IPlayer)target;
        }
    }
}

