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
