using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class Window
    {
        private static Window Instance;

        // Constant values to keep the game's width to height ratio the same no matter the screen size
        private static readonly int DefaultScreenWidth = 256;
        private static readonly int DefaultScreenHeight = 232;
        private static readonly float AspectRatio = (float)DefaultScreenWidth / DefaultScreenHeight;

        // The actual width and height of the window
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        /* Values that make up a rectangle containing the game that keeps its width to height ratio equal to [AspectRatio];
         * This rectangle is centered on the screen
         */
        public int CenteredX { get; private set; }
        public int CenteredY { get; private set; }
        public int CenteredWidth { get; private set; }
        public int CenteredHeight { get; private set; }

        // The amount the game's (centered) width and height are scaled up or down relative to their default values
        public float PrevGameScale { get; private set; }
        public float GameScale { get; private set; }

        private Window() { }

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

            // Calculate how much the game's centered dimensions were scaled up or down
            PrevGameScale = GameScale;
            GameScale = CenteredWidth / DefaultScreenWidth;
        }

        public static Window GetInstance()
        {
            Instance ??= new Window();
            return Instance;
        }
    }
}
