using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;
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
            Sprite = new ArrowProjectileSprite();
            FramesAlive = 180;
            FramesPassed = 0;
        }
    }
}
