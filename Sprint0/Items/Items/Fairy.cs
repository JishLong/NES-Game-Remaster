using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;
using System;

namespace Sprint0.Items.Items
{
    public class Fairy : AbstractItem
    {
        private readonly static Random RNG = new();
        private Vector2 Velocity;
        private int FramesPassed;

        public Fairy(Vector2 position) : base(new FairySprite(), position) 
        {
            Velocity = GetVelocity();
            FramesPassed = 0;
        }

        public override Types.Item GetItemType()
        {
            return Types.Item.FAIRY;
        }

        public override void Update() 
        {
            base.Update();

            FramesPassed = (FramesPassed + 1) % 20;
            if (FramesPassed == 0) Velocity = GetVelocity();
            Position += Velocity;
        }

        private static Vector2 GetVelocity() 
        {
            float x = RNG.NextSingle() * 2 - 1;
            float y = (float)Math.Sqrt(1 - Math.Pow(x, 2));
            if (RNG.NextSingle() < 0.5) y = -y;
            return new Vector2(x*2, y*2);
        }
    }
}
