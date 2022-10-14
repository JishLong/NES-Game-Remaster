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

        public Player(Game1 game)
        {
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

        public Rectangle GetHitbox() 
        {
            return State.GetHitbox();
        }

        public void ChangeDirection(Types.Direction direction) 
        {
            State.ChangeDirection(direction);
        }

        public void StopAction() 
        {
            State.StopAction();
        }

        public void DoPrimaryAttack() 
        {
            State.DoPrimaryAttack();
        }

        public void DoSecondaryAttack() 
        {
            State.DoSecondaryAttack();
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
            SecondaryWeapon = Types.PlayerWeapon.BOW;
        }
    }
}
