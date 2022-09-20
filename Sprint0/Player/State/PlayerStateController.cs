using System;
namespace Sprint0.Player.State
{
    // This class can handle state transitions.  This should be the only class to modify the state object.
    public class PlayerStateController
    {
        private readonly PlayerState state = new();

        public PlayerStateController()
        {

        }

        public void Update()
        {
            //TODO: this should handle stopping movement if no keys are pressed, and change attack state after n frames.
            state.StopMoving();
        }

        public PlayerState GetState()
        {
            return state;
        }

        public void HandleUpInput()
        {
            state.FaceUp();
            state.StartMoving();
        }


        public void HandleDownInput()
        {
            state.FaceDown();
            state.StartMoving();
            state.MoveDown();
        }

        public void HandleLeftInput()
        {
            state.FaceLeft();
            state.StartMoving();
        }

        public void HandleRightInput()
        {
            state.FaceRight();
            state.StartMoving();
            state.MoveRight();
        }
    }
}

