﻿using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors;
using Sprint0.Levels;

namespace Sprint0.Events
{
    public class EventEnemiesKilledUnlocksDoor : AbstractEvent
    {
        Room Room;
        Door Door;
        public EventEnemiesKilledUnlocksDoor(Room room, Door door)
        {
            Room = room;
            Door = door;
        }

        public override void Update(GameTime gameTime)
        {

            if(Room.CharacterCount == 0 && Fired == false)
            {
                AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().DoorOpen);
                Door.Unlock();
                Fired = true;
            }
        }
    }
}
