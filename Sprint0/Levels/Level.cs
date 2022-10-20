using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using static Sprint0.Types;

namespace Sprint0.Levels
{

    public class Level
    {
        public List<Room> Rooms { get; set; }
        public Room CurrentRoom { get; set; }
        public int StartingRoomIndex;
        public string LevelName { get; }
        public LevelMap Map { get; set; }
        public Level(string levelName, int startingRoomIndex)
        {
            LevelName = levelName;
            Rooms = new List<Room>();
            Map = new LevelMap(LevelName);
            StartingRoomIndex = startingRoomIndex;
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
        public void MakeRoomTransition(RoomTransition direction)
        {
            CurrentRoom.MakeTransition(direction);
        }
        public void GoToNextRoom() 
        {
            int Index = Rooms.FindIndex(a => a == CurrentRoom);
            Index = (Index + 1) % Rooms.Count();
            CurrentRoom = Rooms[Index];
        }
        public void GoToPreviousRoom() 
        {
            int Index = Rooms.FindIndex(a => a == CurrentRoom);
            Index = (Index + Rooms.Count() - 1) % Rooms.Count();
            CurrentRoom = Rooms[Index];
        }
        public void Update(GameTime gameTime)
        {
            CurrentRoom.Update(gameTime);
        }
        public void Draw(SpriteBatch sb)
        {
            CurrentRoom.Draw(sb);
        }
    }   
}
