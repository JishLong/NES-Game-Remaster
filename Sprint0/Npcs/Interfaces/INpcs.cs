using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;

namespace Sprint0.Npcs.Interfaces
{
    public interface INpc : ICharacter
    {
        //void Freeze();
        //void Unfreeze();
        // may need for projectile logic
        //public bool IsProjectile();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
        void Destroy();
    }
}