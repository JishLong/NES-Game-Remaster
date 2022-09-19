using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public abstract class Enemy : IEnemy
    {
        public int health { get; set; }      // Health property
        public ISprite sprite { get; set; }  // Sprite property 
        
        public void takeDamage()
        {
            health--; 

            if (health <= 0)
            {
                destroy();
            }
        }
        public abstract void update();
        public abstract void draw();
        public abstract void destroy();
    }
}
