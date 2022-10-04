using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    public interface IBlock
    {
        public void Draw(SpriteBatch sb);

        public void Update();
    }
}
