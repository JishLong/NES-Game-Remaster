using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Weapons
{
    public interface IWeaponSprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb, Vector2 position);
    }
}
