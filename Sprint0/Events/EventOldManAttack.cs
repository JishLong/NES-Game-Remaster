using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Levels.Events;
using Sprint0.Npcs;
using Sprint0.Sprites.Characters.Npcs;

namespace Sprint0.Events
{
    public class EventOldManAttack : AbstractEvent
    {

        Room CatalystRoom;
        OldMan OldMan;

        public EventOldManAttack(Room catalystRoom, OldMan oldMan)
        {
            CatalystRoom = catalystRoom;
            OldMan = oldMan;
        }

        public override void Update(GameTime gameTime)
        {
            if (Fired == false && OldMan.WasAttacked) 
            {
                AudioManager.GetInstance().StopAudio();
                AudioManager.GetInstance().PlayLooped(Resources.Dababy);
                foreach (var character in CatalystRoom.Characters) 
                {
                    if (character is SecretText) (character as SecretText).Taunt();
                }
                Fired = true;
            }
        }
    }
}
