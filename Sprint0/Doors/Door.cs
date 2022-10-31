using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Doors.States;
using Sprint0.Doors.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Doors
{
    public class Door : IDoor
    {
        public IDoorState State { get; set; }
        public Door(Types.Door doorType)
        {
            // Set initial state on construction.
            State = DoorStateFactory.GetInstance().GetDoor(doorType, this);
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
