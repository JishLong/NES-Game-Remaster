using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Levels
{

    public class Level
    {
        List<Room> rooms;
        Room CurrentRoom;
        public Level()
        {
            rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Room room in rooms)
            {
                room.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach(Room room in rooms)
            {

            }
        }
    }   
}
