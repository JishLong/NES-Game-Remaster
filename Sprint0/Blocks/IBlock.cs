using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Blocks
{
    public interface IBlock
    {
        public void Draw(SpriteBatch sb);

        public void Update();
    }
}
