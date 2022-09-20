using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class Aquamentus : Enemy
    {
        public Aquamentus()
        {
            this.health = 6;    // Data here: https://strategywiki.org/wiki/The_Legend_of_Zelda/Bosses
            this.damage = 2;    // Damage dealt
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
