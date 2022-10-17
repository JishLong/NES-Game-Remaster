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
        public bool IsAttacking { get; set; }
        public Types.Direction FacingDirection { get; set; }

        public Player(Game1 game)
        {
            // Reset() here is essentially just initializing the 4 other fields
            Reset();
            MovementSpeed = new Vector2(2, 2);
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

        public void Reset() 
        {
            State = new PlayerFacingRightState(this);
            Position = new Vector2(0, 0);
            Color = Color.White;
            SecondaryWeapon = Types.PlayerWeapon.ARROW;
        }

        public Rectangle GetHitbox()
        {
            return State.GetHitbox();
        }
    }
}
