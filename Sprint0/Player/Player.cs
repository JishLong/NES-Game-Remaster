using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Player.State.Idle;

namespace Sprint0.Player
{
    public class Player : IPlayer
    {
        // The player's state - determines its behavior
        public IPlayerState State { get; set; }

        // Movement-related properties
        public Vector2 Position { get; set; }
        public Vector2 MovementSpeed { get; }

        // Combat-related properties
        public float Health { get; set; }
        public float MaxHealth { get; }
        public Types.PlayerWeapon SecondaryWeapon { get; set; }

        // Helpful values to check for certain conditions
        public Types.Direction FacingDirection { get; set; }
        public bool IsStationary { get; set; }
        public bool IsChangingDirection { get; set; }
        public bool IsPrimaryAttacking { get; set; }
        public bool IsTakingDamage { get; set; }
        public int DamageFramesPassed { get; set; }

        // An inventory to hold all the player's items - not yet in use
        private Inventory Inventory;
        
        public Player(Game1 game)
        {
            // Initialize the state
            State = new PlayerFacingUpState(this);

            // Initialize the movement-related fields
            Position = new Vector2(Resources.BlueTile.Width * Utils.GameScale * 8, Resources.BlueTile.Height * Utils.GameScale * 8);
            MovementSpeed = new Vector2(4, 4);

            // Initialized the combat-related fields
            Health = 3;
            MaxHealth = 3;
            SecondaryWeapon = Types.PlayerWeapon.ARROW;

            // Initialize the misc. helpful values
            FacingDirection = Types.Direction.UP;
            IsStationary = true;
            IsChangingDirection = false;
            IsPrimaryAttacking = false;
            IsTakingDamage = false;
            
            // Initialize the inventory
            Inventory = new Inventory();
        }

        public void ChangeDirection(Types.Direction direction)
        {
            State.ChangeDirection(direction);
        }

        public void DoPrimaryAttack()
        {
            State.DoPrimaryAttack();
        }

        public void DoSecondaryAttack()
        {
            State.DoSecondaryAttack();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Position);
        }

        public Rectangle GetHitbox()
        {
            return State.GetHitbox();
        }

        public void StopAction()
        {
            State.StopAction();
        }

        public void TakeDamage(int damage, Game1 game) 
        {
            State.TakeDamage(damage, game);
        }

        public void Update()
        {
            State.Update();
        }
    }
}
