using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Enemies.Utils.EnemyUtils;
using static Sprint0.Types;

namespace Sprint0.Levels
{

    public class Level
    {
        private List<Room> Rooms;
        public Room CurrentRoom { get; set; }
        private string LevelName;
        public LevelMap Map { get; set; }
        public Level(string levelName)
        {
            Rooms = new List<Room>();
            LevelName = levelName;
            Map = new LevelMap(LevelName);
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
           
            //TODO: This is NOT how current room should be set...
            CurrentRoom = room;
        }
        public void MakeRoomTransition(RoomTransition direction)
        {
            CurrentRoom.MakeTransition(direction);
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
