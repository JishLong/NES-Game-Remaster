using Microsoft.Xna.Framework;
using Sprint0.Levels;
using Sprint0.Npcs;

namespace Sprint0.Events
{
    public class EventOldManAttack : AbstractEvent
    {

        private readonly Room CatalystRoom;
        private readonly OldMan OldMan;

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
