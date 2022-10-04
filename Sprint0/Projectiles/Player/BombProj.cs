using Microsoft.Xna.Framework;
using Sprint0.Sprites.Npcs;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombProj : AbstractProjectile
    {
        public BombProj(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            FramesAlive = 60;
            FramesPassed = 0;

            Sprite = new BombProjSprite();
        }
    }
}
