using Sprint0.Doors.States;
using Sprint0.Doors.States.EventLockedStates;
using Sprint0.Doors.States.UnlockedStates;
using Sprint0.Doors.States.KeyLockedStates;
using Sprint0.Doors.States.WallStates;
using System;
using Sprint0.Doors.States.SecretUnlockedStates;
using Sprint0.Doors.States.SecretWallStates;

namespace Sprint0.Doors.Utils
{
    public class DoorStateFactory 
    {
        private static DoorStateFactory Instance;
        private DoorStateFactory() { }
        public IDoorState GetDoor(Types.Door doorType, Door door)
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
                case Types.Door.UP_WALL:
                    return new UpWallDoorState(door);
                case Types.Door.RIGHT_WALL:
                    return new RightWallDoorState(door);
                case Types.Door.DOWN_WALL:
                    return new DownWallDoorState(door);
                case Types.Door.LEFT_WALL:
                    return new LeftWallDoorState(door);
                case Types.Door.LEFT_EVENT_LOCKED:
                    return new LeftEventLockedDoorState(door);
                case Types.Door.RIGHT_EVENT_LOCKED:
                    return new RightEventLockedDoorState(door);
                case Types.Door.UP_EVENT_LOCKED:
                    return new UpEventLockedState(door);
                case Types.Door.DOWN_EVENT_LOCKED:
                    return new DownEventLockedDoorState(door);
                case Types.Door.UP_KEY_LOCKED:
                    return new UpKeyLockedDoorState(door);
                case Types.Door.RIGHT_KEY_LOCKED:
                    return new RightKeyLockedDoorState(door);
                case Types.Door.DOWN_KEY_LOCKED:
                    return new DownKeyLockedDoorState(door);
                case Types.Door.LEFT_KEY_LOCKED:
                    return new LeftKeyLockedDoorState(door);
                case Types.Door.UP_SECRET_UNLOCKED:
                    return new UpSecretUnlockedDoorState(door);
                case Types.Door.RIGHT_SECRET_UNLOCKED:
                    return new RightSecretUnlockedDoorState(door);
                case Types.Door.DOWN_SECRET_UNLOCKED:
                    return new DownSecretUnlockedDoorState(door);
                case Types.Door.LEFT_SECRET_UNLOCKED:
                    return new LeftSecretUnlockedDoorState(door);
                case Types.Door.UP_SECRET_WALL:
                    return new UpSecretWallDoorState(door);
                case Types.Door.RIGHT_SECRET_WALL:
                    return new RightSecretWallDoorState(door);
                case Types.Door.DOWN_SECRET_WALL:
                    return new DownSecretWallDoorState(door);
                case Types.Door.LEFT_SECRET_WALL:
                    return new LeftSecretWallDoorState(door);
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
