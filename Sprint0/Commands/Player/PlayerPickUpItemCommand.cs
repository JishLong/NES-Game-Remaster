using Sprint0.Items;
using Sprint0.Player;

namespace Sprint0.Commands.Player
{
    public class PlayerPickUpItemCommand : ITargetedCommand
    {
        private readonly IPlayer Player;
        private readonly IItem Item;

        public PlayerPickUpItemCommand(IPlayer player, IItem item)
        {
            Player = player;
            Item = item;
        }

        public void Execute()
        {
            Player.HoldItem(Item);
        }

        public void SetTarget<T>(T target)
        {
            throw new System.NotImplementedException();
        }
    }
}
