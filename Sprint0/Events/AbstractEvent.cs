using Microsoft.Xna.Framework;
using Sprint0.Levels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Events
{
    public abstract class AbstractEvent : IEvent
    {
        protected bool Fired = false;
        public bool HasFired()
        {
            return Fired;
        }
        public abstract void Update(GameTime gameTime);
    }
}
