using Microsoft.Xna.Framework;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors.States;
using System;

namespace Sprint0.Doors.Utils
{
    public class DoorStateFactory 
    {
        private static DoorStateFactory Instance;
        private DoorStateFactory() { }
        public IDoorState GetDoor(Types.Door doorType, IDoor door)
        {
            switch (doorType)
            {
                case Types.Door.LEFT_UNLOCKED:
                    return new LeftUnlockedDoorState(door);
                case Types.Door.UP_UNLOCKED:
                    return new UpUnlockedDoorState(door);
                case Types.Door.RIGHT_UNLOCKED:
                    return new RightUnlockedDoorState(door);
                case Types.Door.DOWN_UNLOCKED:
                    return new DownUnlockedDoorState(door);
                default:
                    Console.Error.Write("The door state of type " + doorType.ToString() + 
                        " could not be instantiated by the Door State Factory. Does this type exist?");
                    return null;
            }
        }

        public static DoorStateFactory GetInstance()
        {
            if(Instance == null) { 
                Instance = new DoorStateFactory();
            }
            return Instance;
        }
    }
}
