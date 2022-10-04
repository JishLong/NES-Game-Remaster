using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Sprint0.Sprites.Npcs;

namespace Sprint0.Npcs
{
    public class BombProj : AbstractNpc
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;

        bool isProjectile;

        public BombProj(Vector2 position, int updateTimer = 1000)
        {
            //this.IsProjectile = true;
            this.Position = position;
            this.Direction = new Vector2(0, 0); // Starts standing still.
            this.UpdateTimer = updateTimer;
            this.sprite = new Sprites.Npcs.BombProjSprite();
        }

        // public override bool IsProjectile()
        // {
        //     return this.IsProjectile;
        // }
        public override void Destroy()
        {
            // no functionality 
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            // TODO: Logic to delay when bomb 'explodes'
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
            }
                sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}