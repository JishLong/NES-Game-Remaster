using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;
using Sprint0.Player.State.Idle;

namespace Sprint0.Player
{
    public class Player : IPlayer
    {
        public IPlayerState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 MovementSpeed { get; set; }
        public Color Color { get; set; }
        public Types.PlayerWeapon SecondaryWeapon { get; set; }
        public bool IsPrimaryAttacking { get; set; }
        public bool IsStationary { get; set; }
        public Types.Direction FacingDirection { get; set; }
        public float Health { get; }
        public float MaxHealth { get; }

        public float Damage { get; }
        public Inventory Inventory { get; }
        
        public Player(Game1 game)
        {
            // Reset() here is essentially just initializing the 4 other fields
            State = new PlayerFacingRightState(this);
            Position = new Vector2(Resources.BlueTile.Width * Utils.GameScale * 8, Resources.BlueTile.Height * Utils.GameScale * 8);
            Color = Color.White;
            SecondaryWeapon = Types.PlayerWeapon.ARROW;
            IsPrimaryAttacking = false;
            FacingDirection = Types.Direction.RIGHT;
            MovementSpeed = new Vector2(4, 4);
            Health = 3;
            MaxHealth = 3;
            Damage = 1;
            Inventory = new Inventory();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Position);
        }

        public void Update()
        {
            State.Update();
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

        public void StopAction()
        {
            State.StopAction();
        }

        public void TakeDamage() 
        {
            State.TakeDamage();
        }

        public void location(Vector2 newLoc)
        {
            Position = newLoc;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public Rectangle GetHitbox()
        {
            return State.GetHitbox();
        }
    }
}
