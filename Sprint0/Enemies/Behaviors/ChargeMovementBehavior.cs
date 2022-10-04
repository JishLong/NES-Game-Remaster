using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.Interfaces;
using Sprint0.Enemies.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.Behaviors
{
    public class ChargeMovementBehavior : IMovementBehavior 
    {
        public ChargeMovementBehavior(IEnemy enemy)
        {
            
        }

        public EnemyUtils.Direction GetDirection()
        {
            throw new NotImplementedException();
        }

        public Vector2 Move(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
