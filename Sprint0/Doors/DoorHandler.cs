using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using System.Collections.Generic;

namespace Sprint0.Doors
{
    public class DoorHandler
    {
        Dictionary<string, IDoor> Doors;
        public DoorHandler()
        {
            Doors = new Dictionary<string, IDoor>();
        }

        public void AddDoor(string key, IDoor door)
        {
            Doors.Add(key,door);
        }

        public Dictionary<string, IDoor> GetDoors()
        {
            return Doors;
        }

        public List<IBlock> GetBlocks()
        {
            List<IBlock> blocks = new List<IBlock>();
            foreach (IDoor door in Doors.Values)
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
            foreach (IDoor door in Doors.Values)
            {
                door.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (IDoor door in Doors.Values)
            {
                door.Draw(sb);
            }
        }
    }
}
