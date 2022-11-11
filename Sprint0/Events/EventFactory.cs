using Microsoft.Xna.Framework;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors;
using Sprint0.Entities;
using Sprint0.Events;
using Sprint0.Levels.Events;
using System;

namespace Sprint0.Blocks.Utils
{
    public class EventFactory
    {
        private static EventFactory Instance;

        private EventFactory() { }

        public IEvent GetEvent(Types.Event eventType, IEntity catylist, IEntity receiver)
        {
            switch (eventType)
            { 
                case Types.Event.PUSHBLOCK_UNLOCKS_DOOR:
                    return new EventPushBlockUnlocksDoor(catylist as IBlock, receiver as Door);
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
