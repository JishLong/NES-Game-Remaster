using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Entities;
using Sprint0.Levels.Events;
using System.Collections.Generic;
using System.Linq;
using static Sprint0.Types;

namespace Sprint0.Levels
{

    public class Level
    {
        public List<Room> Rooms { get; set; }
        public List<IEntity> Entities { get; set; }
        public EventMaster EventMaster;
        public Room CurrentRoom { get; set; }
        public int StartingRoomIndex;
        public int BossRoomIndex;
        public string LevelName { get; }
        public LevelMap Map { get; set; }
        public Level(string levelName, int startingRoomIndex, int bossRoomIndex)
        {
            LevelName = levelName;
            Rooms = new List<Room>();
            Entities = new List<IEntity>();
            EventMaster = new EventMaster();
            Map = new LevelMap(LevelName);
            StartingRoomIndex = startingRoomIndex;
            BossRoomIndex = bossRoomIndex;
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
        public void AddEntity(IEntity entitiy)
        {
            Entities.Add(entitiy);
        }
        public void AddEvent(IEvent levelEvent)
        {
            EventMaster.AddEvent(levelEvent);
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
            EventMaster.Update(gameTime);
        }
        public void Draw(SpriteBatch sb)
        {
            CurrentRoom.Draw(sb);
        }
    }   
}
