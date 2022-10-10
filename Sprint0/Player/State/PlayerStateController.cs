namespace Sprint0.Player.State
{
    // This class can handle state transitions.  This should be the only class to modify the state object.
    public class PlayerStateController
    {
        private readonly PlayerState state = new();

        private int attackFrameCounter = 0;
        private int damageFrameCounter = 0;

        public PlayerStateController()
        {

        }

        public void Update()
        {
            // movement updating
            if (state.IsMoving())
            {
                if (state.FacingDown())
                {
                    state.MoveDown();
                }
                else if (state.FacingUp())
                {
                    state.MoveUp();
                }
                else if (state.FacingRight())
                {
                    state.MoveRight();
                }
                else
                {
                    state.MoveLeft();
                }
            }

            // how often the player can attack is an arbitrary choice
            if (state.IsAttacking())
            {
                attackFrameCounter++;
            }

            if (attackFrameCounter > 40)
            {
                attackFrameCounter = 0;
                state.StopAttacking();
            }

            // how often the player can take damage
            if (state.IsDamaged())
            {
                damageFrameCounter++;
            }

            if (damageFrameCounter > 40)
            {
                damageFrameCounter = 0;
                state.StopDamage();
            }
        }

        public PlayerState GetState()
        {
            return state;
        }

        public int GetAttackFrame()
        {
            if (attackFrameCounter < 10)
            {
                return 0;
            }
            else if (attackFrameCounter < 20)
            {
                return 1;
            }
            else if (attackFrameCounter < 35)
            {
                return 2;
            }
            else if (attackFrameCounter < 40)
            {
                return 3;
            }
            else
            {
                // indicates something went wrong
                return -1;
            }
        }

        public void HandleUpInput()
        {
            if (!state.IsMoving() && !state.IsAttacking())
            {
                state.FaceUp();
                state.StartMoving();
            }
        }

        public void HandleDownInput()
        {
            if (!state.IsMoving() && !state.IsAttacking())
            {
                state.FaceDown();
                state.StartMoving();
            }
        }

        public void HandleLeftInput()
        {
            if (!state.IsMoving() && !state.IsAttacking())
            {
                state.FaceLeft();
                state.StartMoving();
            }

        }

        public void HandleRightInput()
        {
            if (!state.IsMoving() && !state.IsAttacking())
            {
                state.FaceRight();
                state.StartMoving();
            }
        }

        public void HandleSwordAttackInput()
        {
            if (!state.IsAttacking())
            {
                state.EquipSword();
                state.StartAttacking();
                state.StopMoving();
            }
        }

        public void HandleBombAttackInput()
        {
            if (!state.IsAttacking())
            {
                state.EquipBomb();
                state.StartAttacking();
                state.StopMoving();
            }
        }

        public void HandleArrowAttackInput()
        {
            if (!state.IsAttacking())
            {
                state.EquipBow();
                state.StartAttacking();
                state.StopMoving();
            }
        }

        public void HandleBoommerangAttackInput()
        {
            if (!state.IsAttacking())
            {
                state.EquipBow();
                state.StartAttacking();
                state.StopMoving();
            }
        }


        public void HandleStopMoving()
        {
            state.StopMoving();
        }

        public void HandleTakeDamage()
        {
            state.TakeDamage();
        }

        public void Reset()
        {
            state.Reset();
        }
    }
}
