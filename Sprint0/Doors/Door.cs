﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Doors.States;
using Sprint0.Doors.Utils;
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
        public IDoorState State { get; set; }
        public Door(Room room, Types.Door doorType)
        {
            // Set initial state on construction.
            State = DoorStateFactory.GetInstance().GetDoor(doorType, this);

            // Set Room to the room that this door belongs to.
            Room = room;
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