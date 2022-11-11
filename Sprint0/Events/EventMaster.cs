using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Levels.Events
{
    public class EventMaster
    {

        private List<IEvent> Events;
        public EventMaster()
        {
            Events = new List<IEvent>();
        }

        public void AddEvent(IEvent roomevent)
        {
            Events.Add(roomevent);
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEvent roomevent in Events)
            {
                roomevent.Update(gameTime);
            }
        }
    }
}
