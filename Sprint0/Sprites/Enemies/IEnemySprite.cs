using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Enemies
{
    public  interface IEnemySprite
    {
        void Update(GameTime gameTime);
        void ChangeAnim(string name);
        void Draw(SpriteBatch sb, Vector2 position);
    }
}
