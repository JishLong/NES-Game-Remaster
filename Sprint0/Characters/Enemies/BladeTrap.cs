using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.BladeTrapStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.Enemies
{
    public class BladeTrap : AbstractCharacter
    {
        public BladeTrap(Vector2 position)
        {
            // State
            State = new BladeTrapStillState(this);

            // Movement
            Position = position;
        }
    }
}
