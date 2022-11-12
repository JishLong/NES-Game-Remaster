using Sprint0.Entities;
using Sprint0.Levels;
using Sprint0.Levels.Events;

namespace Sprint0.Events
{
    public static class EventUtils
    {
        /// <summary>
        /// Creates an event and adds it to the specified room.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catylistEntityName"></param>
        /// <param name="receivingEntityName"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        public static void CreateEvent(Room room, Types.Event type, string catylistEntityName, string receivingEntityName)
        {
            IEvent roomEvent;
            switch (type)
            {
                case Types.Event.PUSHBLOCK_UNLOCKS_DOOR:
                    // Get a reference to the catylist entity from entity name.
                    IEntity pushblock = room.Entities.Find(entity => entity.GetName() == catylistEntityName);
                    
                    // Get a reference to the receiver entity from entity name.
                    IEntity door = room.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    // Now construct the event.
                    roomEvent = EventFactory.GetInstance().GetEvent(type, pushblock, door);
                    room.AddEventToRoom(roomEvent);
                    break;

                case Types.Event.ENEMIES_KILLED_DROPS_ITEM:
                    // Catalyst entity is the room itself in this case.
                    IEntity roomEntity = room;
                    // Get a reference to the receiver entity from entity name.
                    IEntity item = room.Entities.Find(entity => entity.GetName() == receivingEntityName);

                    roomEvent = EventFactory.GetInstance().GetEvent(type, room, item);
                    room.AddEventToRoom(roomEvent);
                    break;
            }        
        }
    }
}
