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
            if (!state.IsMoving())
            {
                state.FaceUp();
                state.StartMoving();
                state.MoveUp();
            }
        }


        public void HandleDownInput()
        {
            if (!state.IsMoving())
            {
                state.FaceDown();
                state.StartMoving();
                state.MoveDown();
            }
        }

        public void HandleLeftInput()
        {
            if (!state.IsMoving())
            {
                state.FaceLeft();
                state.StartMoving();
                state.MoveLeft();
            }
                
        }

        public void HandleRightInput()
        {
            if (!state.IsMoving())
            {
                state.FaceRight();
                state.StartMoving();
                state.MoveRight();
            }
        }
    }
}

