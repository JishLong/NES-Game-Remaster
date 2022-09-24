using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{

    public class Bat : AbstractEnemy
    {
        int ElapsedTime;
        int UpdateTimer;

        public Bat(Vector2 position, int updateTimer)
        {
            this.Position = position;


            this.sprite = new Sprites.Enemies.BatSprite();

        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public override void Draw(SpriteBatch sb)
        {
            throw new NotImplementedException();
        }
    }
}
