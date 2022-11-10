using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;
using System;

namespace Sprint0.Items.Items
{
    public class Fairy : AbstractItem
    {
        private readonly static Random RNG = new();

        private Vector2 Velocity;
        // The number of frames the fairy moves in its current direction for
        private const int DirectionFrames = 20;
        private int FramesPassed;

        public Fairy(Vector2 position) : base(new FairySprite(), position, Types.Item.FAIRY) 
        {
            Velocity = PickVelocity();
            FramesPassed = 0;
        }

        public override void Update() 
        {
            base.Update();

            FramesPassed = (FramesPassed + 1) % DirectionFrames;
            if (FramesPassed == 0) Velocity = PickVelocity();
            Position += Velocity;
        }

        private static Vector2 PickVelocity() 
        {
            // We'll give the fairy a random directional vector ranging from (-1, -1) to (1, 1)
            float x = RNG.NextSingle() * 2 - 1;
            float y = RNG.NextSingle() * 2 - 1;

            // We'll also double the speed so it isn't snail-slow
            return new Vector2(x*2, y*2);
        }
    }
}
