using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Doors.States;
using Sprint0.Doors.Utils;
using Sprint0.Entities;
using Sprint0.Levels;
using System.Collections.Generic;

namespace Sprint0.Doors
{
    public class Door : IDoor
    {
        public Room Room;
        public string Name { get; set; }
        public IEntity Parent { get; set; }
        public IDoorState State { get; set; }
        public Door(Room room, Types.Door doorType, string name)
        {
            // Set initial state on construction.
            State = DoorStateFactory.GetInstance().GetDoor(doorType, this);

            // Set name of door
            Name = name + "_" + room.Name.ToLower();

            // Set Room to the room that this door belongs to.
            Room = room;
        }

        public void Unlock()
        { 
            State.Unlock();
        }

        public void Lock()
        {
            State.Lock();
        }

        public List<IBlock> GetBlocks()
        {
            return State.GetBlocks();
        }
        public void Transition()
        {
            Room.MakeTransition(State.GetTransitionDirection());
        }
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }
        public void Draw(SpriteBatch sb)
        {
            State.Draw(sb);
        }  
    }
}
