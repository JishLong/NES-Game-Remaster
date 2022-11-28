using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class GameWindow
    {
        // Controls the scale at which everything is rendered at; higher numbers = higher, sharper resolution
        public static readonly float ResolutionScale = 3f;
        // The width and height at which everything is rendered according to
        public static readonly int DefaultScreenWidth = (int)(256 * ResolutionScale);
        public static readonly int DefaultScreenHeight = (int)(232 * ResolutionScale);
        // The screen's width to height ratio that must always be maintained
        private static readonly float AspectRatio = (float)DefaultScreenWidth / DefaultScreenHeight;

        // The actual width and height of the screen
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        /* Values that make up a rectangle containing the game that keeps its width to height ratio equal to [AspectRatio];
         * This rectangle is centered on the screen
         */
        private int CenteredX;
        private int CenteredY;
        private int CenteredWidth;
        private int CenteredHeight;

        public void UpdateWindowSize(GraphicsDeviceManager graphics)
        {
            // Record the actual dimensions of the screen
            ScreenWidth = graphics.GraphicsDevice.Viewport.Width;
            ScreenHeight = graphics.GraphicsDevice.Viewport.Height;

            // Calculate the width to keep the aspect ratio in check
            if ((int)(ScreenWidth / AspectRatio) > ScreenHeight) CenteredWidth = (int)(ScreenHeight * AspectRatio);
            else CenteredWidth = ScreenWidth;

            // Calculate the height to keep the aspect ratio in check
            if ((int)(ScreenHeight * AspectRatio) > ScreenWidth) CenteredHeight = (int)(ScreenWidth / AspectRatio);
            else CenteredHeight = ScreenHeight;

            /* Calculate the coordinates of a rectangle with width [CenteredWidth] and height [CenteredHeight] that is located
             * in the middle of the screen
             */
            CenteredX = ScreenWidth / 2 - CenteredWidth / 2;
            CenteredY = ScreenHeight / 2 - CenteredHeight / 2;
        }

        public Rectangle GetCenteredArea() 
        {
            return new Rectangle(CenteredX, CenteredY, CenteredWidth, CenteredHeight);
        }
    }
}
