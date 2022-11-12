using Sprint0.Blocks;
using Sprint0.Doors;
using Sprint0.Entities;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Levels.Events;
using System;

namespace Sprint0.Events
{
    public class EventFactory
    {
        private static EventFactory Instance;

        private EventFactory() { }
        /// <summary>
        /// Creates and returns an event.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catylistEntityName"></param>
        /// <param name="receivingEntityName"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        public IEvent GetEvent(Room room, Types.Event eventType, string catylistEntityName, string receivingEntityName)
        {
            switch (eventType)
            {
                case Types.Event.PUSHBLOCK_UNLOCKS_DOOR:
                    // Get a reference to the catylist entity from entity name.
                    IEntity pushblock = room.Entities.Find(entity => entity.GetName() == catylistEntityName);
                    // Get a reference to the receiver entity from entity name.
                    IEntity door = room.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    return new EventPushBlockUnlocksDoor(pushblock as IBlock, door as Door);

                case Types.Event.ENEMIES_KILLED_DROPS_ITEM:
                    // Catalyst entity is the room itself in this case.
                    IEntity roomEntity = room;
                    // Get a reference to the receiver entity from entity name.
                    IEntity item = room.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    return new EventEnemiesKilledDropsItem(room, item as IItem);
                case Types.Event.ENEMIES_KILLED_UNLOCKS_DOOR:
                    // Catalyst entity is the room itself in this case.
                    roomEntity = room;
                    // Get a reference to the receiver entity from entity name.
                    door = room.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    return new EventEnemiesKilledUnlocksDoor(room, door as Door);
                default:
                    Console.Error.Write("The event of type " + eventType.ToString() +
                        " could not be instantiated by the Event Factory. Does this type exist?");
                    return null;
            }        
        }
        public static EventFactory GetInstance()
        {
            Instance ??= new EventFactory();
            return Instance;
        }
    }
}
