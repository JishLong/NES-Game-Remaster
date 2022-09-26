using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites
{
    public class Animation
    {
        private List<Rectangle> SourceRects; // X pos, Y pos, width, height
        private int Width;
        private int Height;
        private int ElapsedTime = 0;
        private int UpdateTimer;
        public int CurrentFrame { get; private set; }
        public int NumFrames { get; private set; }

        /// <summary>
        /// Constructor for the 'Animation' class.
        /// </summary>
        /// <param name="width">Width of the sprite in this animation.</param>
        /// <param name="height">Height of the sprite in this animation.</param>
        /// <param name="animSpeed">Scales the playback speed of the animation.</param>
        /// <param name="frameCoords">Specify a list of frame coordinates upon construction.</param>
        public Animation(int width, int height, int animSpeed)
        {

            this.SourceRects = new List<Rectangle>();
            this.Width = width;
            this.Height = height;
            this.UpdateTimer = (1 / animSpeed) * 200;  // animation speed is used to calculate the timer.
        }
        /// <summary>
        /// Returns source rectangle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>x, y, width, height of the frame at the given index.</returns>
        public Rectangle SourceRectAt(int index)
        {
            return SourceRects[index];
        }

        /// <summary>
        /// Returns the current frame's source rectangle.
        /// </summary>
        /// <returns>x, y, width, height of the current frame.</returns>
        public Rectangle CurrentRect()
        {
            return SourceRects[CurrentFrame];
        }

        public void Update(GameTime gameTime)
        {
            var elapsedMilliSeconds = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            ElapsedTime += elapsedMilliSeconds;

            // Update frame.
            if (ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
                CurrentFrame++;
                if (CurrentFrame >= NumFrames)
                {
                    CurrentFrame = 0;
                }
            }
        }

        /// <summary>
        /// Adds a frame to this animation instance's list of frame coordinates.
        /// </summary>
        /// <requires>
        /// index is < |this.frameCoords| and index is >= 0
        /// </requires>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="index">Specify the index at which to place the new frame (by default, the frame will be appended at the end of the frame coordinates list.)</param>
        public void AddFrame(int x, int y, int width = -1, int height = -1, int index = -1)
        {
            if (width == -1 || height == -1)
            {
                width = this.Width;
                height = this.Height;
            }

            if (index == -1)
            {
                this.SourceRects.Add(new Rectangle(x, y, width, height));
            }
            else
            {
                this.SourceRects.Insert(index, new Rectangle(x, y, width, height));
            }

            this.NumFrames++;
        }
    }
}

