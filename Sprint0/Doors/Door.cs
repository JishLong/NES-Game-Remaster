using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Doors.States;
using Sprint0.Doors.Utils;
using Sprint0.Entities;
using Sprint0.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Doors
{
    public class Door : IDoor
    {
        public Room Room;
        public string Name;
        private IEntity Parent;
        public IDoorState State { get; set; }
        public Door(Room room, Types.Door doorType, string name)
        {
            // Set initial state on construction.
            State = DoorStateFactory.GetInstance().GetDoor(doorType, this);

            // Set name of door
            Name = name + "_" + room.RoomName.ToLower();

            // Set Room to the room that this door belongs to.
            Room = room;
        }
        public IEntity GetParent()
        {
            return Parent;
        }

        public void SetParent(IEntity entity)
        {
            Parent = entity;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string value)
        {
            Name = value;
        }

        public void Unlock()
        { 
            State.Unlock();
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
