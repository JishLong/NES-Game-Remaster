using Microsoft.Xna.Framework;

namespace Sprint0.Player
{
    public class EnemyState
    {
        private bool isMoving = false;
        private bool isAttacking = false;
        private bool isDamaged = false;

        private Vector2 position;
        // TODO: not sure if enemy speeds vary
        // private readonly int movementSpeed = 1;

        private enum FacingDirection { up, down, left, right }
        // enemies face downwards by default
        private FacingDirection facingDirection = FacingDirection.down;

        public EnemyState()
        {
            // initialization logic is simple default assignments
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void MoveDown()
        {
            this.position.Y += movementSpeed;
        }

        public void MoveRight()
        {
            this.position.X += movementSpeed;
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
            // TODO: enemy health logic
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
