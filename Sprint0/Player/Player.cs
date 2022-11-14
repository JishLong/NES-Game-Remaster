using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Items;
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

        // Combat-related properties
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public Types.Projectile SecondaryWeapon { get; set; }

        // Helpful values to check for certain conditions
        public Types.Direction FacingDirection { get; set; }
        public bool IsStationary { get; set; }

        // An inventory to hold all the player's items - not yet in use
        public HUD HUD { get; private set; }
        public Inventory Inventory { get; private set; }
        
        public Player()
        {
            // Initialize the state
            State = new PlayerIdleState(this, true);

            // Initialize the movement-related fields
            Position = new Vector2(Resources.BlueTile.Width * Utils.GameScale * 8, Resources.BlueTile.Height * Utils.GameScale * 8);

            // Initialized the combat-related fields
            Health = 6;
            MaxHealth = 6;
            SecondaryWeapon = Types.Projectile.ARROW_PROJ;

            // Initialize the misc. helpful values
            FacingDirection = Types.Direction.UP;
            IsStationary = true;

            // Initialize the inventorys
            HUD = new HUD();
            Inventory = new Inventory();
        }

        public void Capture(ICommand goToBeginningCommand) 
        {
            State.Capture(goToBeginningCommand);
        }

        public void Move(Types.Direction direction)
        {
            State.Move(direction);
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

        public void HoldItem(IItem item) 
        {
            State.HoldItem(item);
        }

        public void StopAction()
        {
            State.StopAction();
        }

        public void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game, Types.Direction direction = Types.Direction.NO_DIRECTION) 
        {
            State.ChangeHealth(healthAmount, maxHealthAmount, game, direction);
        }

        public void Update()
        {
            State.Update();
        }
    }
}
