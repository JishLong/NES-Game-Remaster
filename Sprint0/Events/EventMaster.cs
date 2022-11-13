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
        private List<IEvent> EventsPendingRemoval;
        public EventMaster()
        {
            Events = new List<IEvent>();
            EventsPendingRemoval = new List<IEvent>();
        }

        public void AddEvent(IEvent roomevent)
        {
            Events.Add(roomevent);
        }

        public void RemoveEvent(IEvent roomevent)
        {
            Events.Remove(roomevent);
        }
        public void Update(GameTime gameTime)
        {
            foreach (IEvent roomevent in Events)
            {
                if (roomevent.HasFired())
                {
                    EventsPendingRemoval.Add(roomevent);
                }
                roomevent.Update(gameTime);
            }

            foreach (IEvent roomevent in EventsPendingRemoval)
            {
                RemoveEvent(roomevent);
            }

            EventsPendingRemoval.Clear();
        }
    }
}
