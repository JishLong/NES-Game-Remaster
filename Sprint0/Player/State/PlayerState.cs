namespace Sprint0.Player
{
    public class PlayerState
    {
        private bool isMoving = false;
        private bool isAttacking = false;
        private bool isDamaged = false;

        private enum FacingDirection { up, down, left, right }
        private FacingDirection facingDirection = FacingDirection.right;

        //TODO: determine exactly what weapns Link needs to have
        private enum CurrentWeapon { }

        public PlayerState()
        {
            // initialization logic is simple default assignments
        }

        public bool IsMoving()
        {
            return isMoving;
        }

        public void StartMoving()
        {
            isMoving = true;
        }

        public void StopMoving()
        {
            isMoving = false;
        }

        public bool IsAttacking()
        {
            return isAttacking;
        }

        public bool IsDamaged()
        {
            return isDamaged;
        }

        public void TakeDamage()
        {
            this.isDamaged = true;
        }

        public bool FacingUp()
        {
            return facingDirection == FacingDirection.up;
        }

        public void FaceUp()
        {
            this.facingDirection = FacingDirection.up;
        }

        public bool FacingDown()
        {
            return facingDirection == FacingDirection.down;
        }

        public void FaceDown()
        {
            this.facingDirection = FacingDirection.down;
        }

        public bool FacingLeft()
        {
            return facingDirection == FacingDirection.left;
        }

        public void FaceLeft()
        {
            this.facingDirection = FacingDirection.left;
        }

        public bool FacingRight()
        {
            return facingDirection == FacingDirection.right;
        }

        public void FaceRight()
        {
            this.facingDirection = FacingDirection.right;
        }
    }
}

