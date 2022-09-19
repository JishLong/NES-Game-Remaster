using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class Skeleton : Enemy
    {
        public Skeleton()
        {
            this.health = 2;    // arbitrary health value. I think they die in like a single hit?
        }

        public override void destroy()
        {
            // not sure what to do here yet...
            throw new NotImplementedException();
        }
        public override void update()
        {
            
        }

        public override void draw()
        {
            // TODO: public properties for the graphics device manager and the sprite batch from the main game class?
            //psuedo-code:
            // sb = ZeldaGame.sprite_batch;
            // graphics = ZeldaGame.graphics_device_manager;
            // w = graphics.w;
            // h = graphics.h;
            // sprite.Draw(sb, w, h);
        }

    }
}
