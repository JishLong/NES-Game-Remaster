using Microsoft.Xna.Framework.Input;

namespace Sprint0.Controllers
{
    // Maps one or more keyboard keys to some method of user keyboard input
    public class ActionMap
    {
        /* Used to reference the method of keyboard input that activates a key map
         * 
         * [HELD]: any of the keys in the mapping are being held down
         * [UP]: any of the keys in the mapping are not being held down
         * [PRESSED]: at least one of the keys in the mapping has *JUST NOW* been pressed down
         * [RELEASED]: at least one of the keys in the mapping has *JUST NOW* been released
         */
        public enum KeyState {HELD, UP, PRESSED, RELEASED};

        private readonly KeyState State;
        private readonly Keys[] KeyList;

        public ActionMap(KeyState state, params Keys[] keyList)
        {
            State = state;
            KeyList = keyList;
        }

        public bool IsActivated(KeyboardState prevState, KeyboardState currentState)
        {
            foreach (var key in KeyList)
            {
                if (State == KeyState.HELD && currentState.IsKeyDown(key)
                    || State == KeyState.UP && currentState.IsKeyUp(key)
                    || State == KeyState.PRESSED && currentState.IsKeyDown(key) && prevState.IsKeyUp(key)
                    || State == KeyState.RELEASED && currentState.IsKeyUp(key) && prevState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
