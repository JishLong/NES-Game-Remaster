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
        /// <param name="catalystEntityName"></param>
        /// <param name="receivingEntityName"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        public IEvent GetEvent(Level level, Types.Event eventType, string catalystEntityName, string receivingEntityName)
        {
            switch (eventType)
            {
                case Types.Event.PUSHBLOCK_UNLOCKS_DOOR:
                    // Get a reference to the catalyst entity from entity name.
                    IEntity pushblock = level.Entities.Find(entity => entity.GetName() == catalystEntityName);
                    // Get a reference to the receiver entity from entity name.
                    IEntity door = level.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    return new EventPushBlockUnlocksDoor(pushblock as IBlock, door as Door);

                case Types.Event.ENEMIES_KILLED_DROPS_ITEM:
                    // Catalyst entity is the room itself in this case.
                    IEntity catalystRoom = level.Entities.Find(entity => entity.GetName() == catalystEntityName);
                    // Get a reference to the receiver entity from entity name.
                    IEntity item = level.Entities.Find(entity => entity.GetName() == receivingEntityName);
                    // Get a reference to the room that owns the item.
                    IEntity owningRoom = level.Entities.Find(entity => entity.GetName() == item.GetParent().GetName());

                    return new EventEnemiesKilledDropsItem(catalystRoom as Room, owningRoom as Room, item as IItem);
                case Types.Event.ENEMIES_KILLED_UNLOCKS_DOOR:
                    // Catalyst entity is the room itself in this case.
                    IEntity room = level.Entities.Find(entity => entity.GetName() == catalystEntityName);
                    // Get a reference to the receiver entity from entity name.
                    door = level.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    return new EventEnemiesKilledUnlocksDoor(room as Room, door as Door);
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
