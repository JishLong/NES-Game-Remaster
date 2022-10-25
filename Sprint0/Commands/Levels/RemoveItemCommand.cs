using Sprint0.Items;
using Sprint0.Levels;

namespace Sprint0.Commands.Levels
{
    public class RemoveItemCommand : ICommand
    {
        private readonly Room Room;
        private readonly IItem Item;

        public RemoveItemCommand(Room room, IItem item)
        {
            Room = room;
            Item = item;
        }

        public void Execute()
        {
            Room.RemoveItemFromRoom(Item);
        }
    }
}
