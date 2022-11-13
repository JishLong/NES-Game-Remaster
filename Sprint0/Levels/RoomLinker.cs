using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Levels
{
    public class RoomLinker
    {
        public RoomLinker()
        {
        }

        public Room AddSecretTransitionToRoom(List<Room> levelRooms, Room room, int[,] map, int row, int col)
        {
            int rightValue = map[row, col + 1];
            Room secretRoom = levelRooms.Find(room => room.RoomName == "Room" + rightValue);
            room.AddTransition(secretRoom, Types.RoomTransition.SECRET);
            return secretRoom;
        }
        public void AddTransitionsToRoom(List<Room> levelRooms, Room room, int[,] map, int row, int col)
        {
            List<Room> adjaecntRooms = new List<Room>();
            int aboveValue = map[row - 1, col];
            int rightValue = map[row, col + 1];
            int leftValue = map[row, col - 1];
            int belowValue = map[row + 1, col];

            if (aboveValue > 0)  // Check the area above this room.
            {
                Room roomAbove = levelRooms.Find(room => room.RoomName == "Room" + aboveValue);
                room.AddTransition(roomAbove, Types.RoomTransition.UP);
            }
            else
            {
                room.AddTransition(null, Types.RoomTransition.UP);
            }

            if (rightValue > 0)  // Check the area to the right of this room.
            {
                Room roomRightOf = levelRooms.Find(room => room.RoomName == "Room" + rightValue);
                room.AddTransition(roomRightOf, Types.RoomTransition.RIGHT);
            }
            else
            {
                room.AddTransition(null, Types.RoomTransition.RIGHT);
            }

            if (belowValue > 0)  // Check the area below this room.
            {
                Room roomBelow = levelRooms.Find(room => room.RoomName == "Room" + belowValue);
                room.AddTransition(roomBelow, Types.RoomTransition.DOWN);
            }
            else
            {
                room.AddTransition(null, Types.RoomTransition.DOWN);
            }

            if (leftValue > 0)  // Check the area to the left of this room.
            {
                Room roomLeftOf = levelRooms.Find(room => room.RoomName == "Room" + leftValue);
                room.AddTransition(roomLeftOf, Types.RoomTransition.LEFT);
            }
            else
            {
                room.AddTransition(null, Types.RoomTransition.LEFT);
            }
        }
        public void LinkRooms(Level level)
        {
            int[,] map = level.Map.MapArray;
            int mapSize = map.GetLength(0); // The map is always square.
            int max = level.Map.MaxNumRooms;
            List<Room> rooms = level.Rooms;

            for (int row = 0; row < mapSize - 1; row++)
            {
                for (int col = 0; col < mapSize - 1; col++)
                {
                    int valAtIndex = map[row, col];
                    if (valAtIndex < max + 1) // If this is a room. (empty spaces are set to a number that is 1 greater than the maximum number of rooms.)
                    {
                        if(valAtIndex < 0)
                        {
                            /*
                             * We want this: 
                             * ROOM.SECRET = SECRETROOM
                             * SECRETROOM.SECRET = ROOM
                             */ 

                            valAtIndex *= -1;
                            Room room = rooms.Find(room => room.RoomName == "Room" + valAtIndex);
                            Room secretRoom = AddSecretTransitionToRoom(rooms, room, map, row, col);
                            secretRoom.AddTransition(room, Types.RoomTransition.SECRET); // Link the secret room to the original room.
                        }
                        else
                        {
                            Room room = rooms.Find(room => room.RoomName == "Room" + valAtIndex);
                            AddTransitionsToRoom(rooms, room, map, row, col);
                        }
                    }
                }

                level.CurrentRoom = rooms.Find(room => room.RoomName == "Room" + level.StartingRoomIndex);
            }
        }
    }
}






