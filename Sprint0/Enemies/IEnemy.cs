using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public interface IEnemy
    {
        void takeDamage();
        void update();

        void draw();
        void destroy();

    }
}
