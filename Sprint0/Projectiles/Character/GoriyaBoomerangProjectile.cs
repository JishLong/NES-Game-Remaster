using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;
using Sprint0.Sprites.Projectiles.Character;
using Sprint0.Sprites.Projectiles.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Projectiles.Character
{
    public class GoriyaBoomerangProjectile : AbstractProjectile
    {

        public GoriyaBoomerangProjectile(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            FramesAlive = 300;
            FramesPassed = 0;
            Velocity = velocity * 2;
            Sprite = new GoriyaBoomerangSprite();
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if(FramesPassed < (FramesAlive / 2))
            {
                Position += Velocity;
            } else if(FramesPassed >= FramesAlive / 2)
            {
                Position -= Velocity;
            }
        }
    }
}
