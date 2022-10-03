using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Blocks
{
    public interface IBlock
    {
        public void Draw(SpriteBatch sb);

        // Will possibly be useful in the future - currently sees very limited use
        public void Update();
    }
}
