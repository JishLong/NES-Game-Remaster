using Microsoft.Xna.Framework;

namespace Sprint0.Player
{
    public class PlayerState
    {
        private bool isMoving = false;
        private bool isAttacking = false;
        private bool isDamaged = false;

        private Vector2 position;
        private readonly int movementSpeed = 2;

        private enum FacingDirection { up, down, left, right }
        private FacingDirection facingDirection = FacingDirection.right;

        //TODO: determine exactly what weapons Link needs to have
        private enum Weapon { Sword, Bow, MagicStaff }
        private Weapon currentWeapon;

        public PlayerState()
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

        public void MoveLeft()
        {
            this.position.X -= movementSpeed;
        }

        public void MoveUp()
        {
            this.position.Y -= movementSpeed;
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

        public void StartAttacking()
        {
            isAttacking = true;
        }

        public void StopAttacking()
        {
            isAttacking = false;
        }

        public void EquipSword()
        {
            currentWeapon = Weapon.Sword;
        }

        public bool SwordEquipped()
        {
            return currentWeapon == Weapon.Sword;
        }

        public void EquipBow()
        {
            currentWeapon = Weapon.Bow;
        }

        public bool BowEquipped()
        {
            return currentWeapon == Weapon.Bow;
        }

        public void EquipStaff()
        {
            currentWeapon = Weapon.MagicStaff;
        }

        public bool StaffEquipped()
        {
            return currentWeapon == Weapon.MagicStaff;
        }

        public bool IsDamaged()
        {
            return isDamaged;
        }

        public void TakeDamage()
        {
            this.isDamaged = true;
        }

        public void StopDamage()
        {
            this.isDamaged = false;
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

        public void Reset() 
        {
            this.facingDirection = FacingDirection.right;
            position = new Vector2(0, 0);
            isMoving = false;
            isAttacking = false;
            isDamaged = false;
            currentWeapon = Weapon.Sword;
        }
    }
}
