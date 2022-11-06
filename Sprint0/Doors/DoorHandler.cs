using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Doors
{
    public class DoorHandler
    {
        List<IDoor> Doors;
        public DoorHandler()
        {
            Doors = new List<IDoor>();
        }

        public void AddDoor(IDoor door)
        {
            Doors.Add(door);
        }

        public List<IDoor> GetDoors()
        {
            return Doors;
        }

        public List<IBlock> GetBlocks()
        {
            List<IBlock> blocks = new List<IBlock>();
            foreach (IDoor door in Doors)
            {
                // For each door, add all of the blocks owned by that door to this collection.
                if(door.GetBlocks() != null) // TODO: Get rid of this null check. Should not need it after everything is implemented.
                {
                    blocks.AddRange(door.GetBlocks());
                } 
            }
            return blocks;
        }

        public void Update(GameTime gameTime)
        {
            foreach (IDoor door in Doors)
            {
                door.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (IDoor door in Doors)
            {
                door.Draw(sb);
            }
        }
    }
}
