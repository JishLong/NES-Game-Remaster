using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Items
{
    public interface IItem
    {
        public void Draw(SpriteBatch sb);

        public void Update();
    }
}
