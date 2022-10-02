using System;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Controllers
{
    // Maps a command to one or more keyboard keys
    public class KeyMap
    {
        /* Used to reference the circumstance that activates a key map
         * 
         * [HELD]: any of the keys in the mapping are being held down
         * [UP]: any of the keys in the mapping are not being held down
         * [PRESSED]: at least one of the keys in the mapping has *JUST NOW* been pressed down
         * [RELEASED]: at least one of the keys in the mapping has *JUST NOW* been released */
        public enum KeyState {HELD, UP, PRESSED, RELEASED};

        private KeyState state;
        private Keys[] keys;

        public KeyMap(KeyState state, params Keys[] keys)
        {
            this.state = state;
            this.keys = keys;
        }

        public Boolean IsActivated(KeyboardState prevState, KeyboardState currentState)
        {
            foreach (var key in keys)
            {
                if (state == KeyState.HELD && currentState.IsKeyDown(key)
                    || state == KeyState.UP && currentState.IsKeyUp(key)
                    || state == KeyState.PRESSED && currentState.IsKeyDown(key) && prevState.IsKeyUp(key)
                    || state == KeyState.RELEASED && currentState.IsKeyUp(key) && prevState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
